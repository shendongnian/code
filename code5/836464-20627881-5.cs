          public static void SetCookie(string key, string value, int dayExpires)
        {
            if (Request.Cookies[key] != null)
            {
                var c = HttpContext.Current.Request.Cookies[key];
                c.Expires = DateTime.Now.AddDays(-10);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            HttpCookie encodedCookie = HttpSecureCookie.Encode(new HttpCookie(key, value));
            encodedCookie.Expires = DateTime.Now.AddDays(dayExpires);
            HttpContext.Current.Response.Cookies.Add(encodedCookie);
        }
