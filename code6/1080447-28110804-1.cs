    class OWConnector
    {
        // same as in OP...
        public async Task<bool> authAsync(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>(@"form_name", @"sign-in"),
                new KeyValuePair<string, string>(@"identity", username),
                new KeyValuePair<string, string>(@"password", password),
                new KeyValuePair<string, string>(@"remember", @"on"),
                new KeyValuePair<string, string>(@"submit", @"Sign In"),
            });
            RequestResponse r = await PostRequest(@"/", content);
            Boolean cookieFound = false;
            foreach (Cookie c in cookieJar.GetCookies(baseUri))
            {
                if (c.Name == @"ow_login")
                {
                    cookieFound = true;
                }
            }
            return cookieFound;
        }
    }
