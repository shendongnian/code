    var cookie = new HttpCookie("CookieName")
                {
                    Value = JsonConvert.SerializeObject(model), // if value is object, else use simple string
                    Expires = DateTime.Now.AddYears(1)
                };
                Response.Cookies.Add(cookie);
