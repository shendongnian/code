    languageCookie.Value = Server.UrlDecode(Request.QueryString["l"])
                             .Replace("\r", string.Empty)
                             .Replace("%0d", string.Empty)
                             .Replace("%0D", string.Empty)
                             .Replace("\n", string.Empty)
                             .Replace("%0a", string.Empty)
                             .Replace("%0A", string.Empty);
