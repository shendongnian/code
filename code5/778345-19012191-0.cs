    void context_BeginRequest(object sender, EventArgs e)
    {
        // eat the cookie (if any) and set the culture
        if (HttpContext.Current.Request.Cookies["lang"] != null)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
            string lang = cookie.Value;
            var culture = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
