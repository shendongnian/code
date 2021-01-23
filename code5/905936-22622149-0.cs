    public AuthenticationResult VerifyAuthentication(System.Web.HttpContextBase context)
        {
            string code = context.Request.QueryString["code"];
            string rawUrl = context.Request.Url.OriginalString;
            if (rawUrl.Contains(":80/"))
                {
                rawUrl = rawUrl.Replace(":80/", "/");
                }
            if (rawUrl.Contains(":443/"))
            {
                rawUrl = rawUrl.Replace(":443/", "/");
            }
            //From this we need to remove code portion
            rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");
            IDictionary<string, string> userData = GetUserData(code, rawUrl);
            if (userData == null)
                return new AuthenticationResult(false, ProviderName, null, null, null);
            string id = userData["id"];
            string username = userData["username"];
            userData.Remove("id");
            userData.Remove("username");
            var result = new AuthenticationResult(true, ProviderName, id, username, userData);
            return result;
        }
