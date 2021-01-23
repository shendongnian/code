    private ABHomeModel HandleWhiteBoxCookie(ABHomeModel model)
            {
                var whiteBox = _whiteBoxService.GetActiveWhiteBox();
    
                if (whiteBox != null)
                {
                    const string cookieName = "whiteBox";
    
                    var whiteBoxCookie = HttpContext.Request.Cookies.Get(cookieName);
    
                    if (whiteBoxCookie != null)
                    {
                        var displayedTimes = Convert.ToInt32(whiteBoxCookie.Value);
                        if (displayedTimes < 2)
                        {
                            displayedTimes++;
    
                            var cookie = new HttpCookie(cookieName, displayedTimes.ToString())
                            {
                                HttpOnly = true,
                                Secure = false
                            };
    
                            HttpContext.Response.Cookies.Set(cookie);
                            ViewBag.IsWhiteBoxActive = true;
                        }
                        else
                        {
                            ViewBag.IsWhiteBoxActive = false;
                        }
                    }
                    else
                    {
                        var cookie = new HttpCookie(cookieName, "1")
                        {
                            HttpOnly = true,
                            Expires = DateTime.Now.AddMonths(1),
                            Secure = false
                        };
    
                        HttpContext.Response.Cookies.Add(cookie);
                        ViewBag.IsWhiteBoxActive = true;
                    }
    
                    model.WhiteBox = whiteBox;
                }
    
                return model;
            }
