       [HttpPost]
        public ActionResult Login(MVVMLogin LoginData)
        {
          //validate user against database
          var IsValid = true;
            if (IsValid == true)
            {
                    
                    var Roles = "admin";
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        LoginData.Username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(20), //Expires
                        false,
                        Roles,
                        "/");
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    
            }
            return View();
        }
