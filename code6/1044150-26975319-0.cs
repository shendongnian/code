    Server Side code to Get and Set Cookies :
            public void SetCookie(string key, string value, TimeSpan expires)
            {
                var encodedCookie = new HttpCookie(key, value);
    
                encodedCookie.HttpOnly = true;
    
                if (HttpContext.Current.Request.Cookies[key] != null)
                {
                    var cookieOld = HttpContext.Current.Request.Cookies[key];
                    cookieOld.Expires = DateTime.Now.Add(expires);
                    cookieOld.Value = encodedCookie.Value;
                    HttpContext.Current.Response.Cookies.Add(cookieOld);
                }
                else
                {
                    encodedCookie.Expires = DateTime.Now.Add(expires);
                    HttpContext.Current.Response.Cookies.Add(encodedCookie);
                }
            }
    
            public string GetCookie(string key)
            {
                string value = string.Empty;
                HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
    
                if (cookie != null)
                {
                    // For security purpose, we need to encrypt the value.
                    HttpCookie decodedCookie = cookie;
                    value = decodedCookie.Value;
                }
                return value;
            }
    
    
    
    
    Client Side code to Get and Set cookies
    
        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toGMTString();
            document.cookie = cname + "=" + cvalue + "; " + expires;
        }
    
        function getCookie(cname) {
            var name = cname + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1);
                if (c.indexOf(name) != -1) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }
