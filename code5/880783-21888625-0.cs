    CookieContainer newCookies = new CookieContainer();
    newCookies.Add(new Uri("https://www.amazon.co.uk/"), new Cookie
                {
                    Name = c.Name,
                    Version = 0,
                    Comment = c.Comment,
                    CommentUri = c.CommentUri,
                    Discard = c.Discard,
                    Domain = c.Domain,
                    Expired = c.Expired,
                    Expires = c.Expires,
                    HttpOnly = c.HttpOnly,
                    Path = c.Path,
                    Port = c.Port,
                    Secure = c.Secure,
                    Value = c.Value
                });
