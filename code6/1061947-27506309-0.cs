     [HttpPost]
        public ActionResult Login(string accountId)
        {
            var url = "http://...."
            var request = (HttpWebRequest)WebRequest.Create(url + "/Account/WamLogin/");
            request.Headers.Add("user", accountId);
            request.CookieContainer = new CookieContainer();
            var response = (HttpWebResponse)request.GetResponse();
            foreach (Cookie cook in response.Cookies)
            {
                Response.Cookies.Add(new HttpCookie(cook.Name, cook.Value) { Expires = cook.Expires, HttpOnly = cook.HttpOnly, Domain = cook.Domain });
            }
            return new RedirectResult(url);
        }
