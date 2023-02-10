using FbAuth.Models;
using GoogleAuthentication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FbAuth.Controllers
{
    public class GAnewController : Controller
    {
        // GET: GAnew
        public ActionResult Index()
        {
            GoogleProfile profile = new GoogleProfile();
            var clientId = "1062711402532-tgocekhkv0b0namubk7fc3ftr1jemour.apps.googleusercontent.com";
            var url = "https://localhost:44375/GAnew/GoogleLoginCallback";
            var response = GoogleAuth.GetAuthUrl(clientId, url);
            ViewBag.response = response;
            return View(profile);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> GoogleLoginCallback(string code)
        {
            var clientId = "1062711402532-tgocekhkv0b0namubk7fc3ftr1jemour.apps.googleusercontent.com";
            var url = "https://localhost:44375/GAnew/GoogleLoginCallback";
            var clientsecret = "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";
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientsecret, url);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
            GoogleProfile profile = new GoogleProfile();
            profile = JsonConvert.DeserializeObject<GoogleProfile>(userProfile);

            return View(profile);
        }
    }
}