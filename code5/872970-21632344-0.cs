        [AllowAnonymous]
        public ActionResult Login()
        {
            Response.Cookies.Add(CreateExpiredBlankCookie("ASP.NET_SessionId"));
            return View();
        }
        private HttpCookie CreateExpiredBlankCookie(string name)
        {
            var cookie = new HttpCookie(name, "");
            cookie.Expires = DateTime.Now.AddDays(-1);
            return cookie;
        }
