    protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var cultureName = RouteData.Values["culture"] as string;
            var cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null && string.IsNullOrEmpty(cultureName))
            {
                cultureName = cultureCookie.Value;
            }
            if (cultureName == null)
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; 
            cultureName = CultureHelper.GetImplementedCulture(cultureName); 
            if (RouteData.Values["culture"] as string != cultureName)
            {
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too
                var cookie = Request.Cookies["_culture"];
                if (cookie != null)
                    cookie.Value = cultureName;   // update cookie value
                else
                {
                    cookie = new HttpCookie("_culture") { Value = cultureName, Expires = DateTime.Now.AddYears(1) };
                }
                Response.Cookies.Add(cookie);
                // Redirect user
                Response.RedirectToRoute(RouteData.Values);
            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }
