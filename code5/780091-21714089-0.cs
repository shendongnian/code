     public override AuthenticationResult VerifyAuthentication(HttpContextBase context, Uri returnPageUrl)
        {
            string code = context.Request.QueryString["code"];
            string rawUrl = context.Request.Url.OriginalString;
            //From this we need to remove code portion
            rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");
            IDictionary<string, string> userData =    GetUserData(QueryAccessToken(returnPageUrl, code));
            if (userData == null)
                return new AuthenticationResult(false, ProviderName, null, null, null);
            
            
            AuthenticationResult result = new AuthenticationResult(true, ProviderName, userData["id"], userData["name"], userData);
            userData.Remove("id");
            userData.Remove("name");
            return result;
        }
    }
 
