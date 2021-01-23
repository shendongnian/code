        public String get_Cookie(String cookieName)
                {
                    HTTPRequest Request = this.Context.Request;//Added to better understanding.
                    if (Request.Cookies.Get(cookieName) != null)
                    {
                        return HttpUtility.UrlDecode(Request.Cookies.Get(cookieName).Value);
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
