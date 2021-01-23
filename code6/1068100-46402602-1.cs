        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            Credentials credentials = new Credentials();
           
            credentials.Username = formCollection["username"].ToString();
            credentials.Password = formCollection["password"].ToString();
            var result = ApiHelper.PostLogin<FRP.WebApp.Models.Credentials>(MicroService.Login, "/api/Authenticate/Login", credentials, credentials.Username, credentials.Password);
            ViewData["username"] = formCollection["username"];
            ViewData["password"] = formCollection["password"];
            if (result.Status == Sonata.Framework.Models.BusinessStatus.Ok)
            {
                ViewData["error"] = "";
                return View("About", result);
            }
            else
            {
                RegistrationViewModel model = new RegistrationViewModel();
                model.Years = ViewHelper.GetYears();
                ViewData["error"] = "InValid";
                return View("Index",model);
            }
        }
