        public CookieContainer CreateAuthorizationCookies(string login, string password)
        {
            var result = new CookieContainer();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var webRequestHandler = new WebRequestHandler();
            webRequestHandler.CookieContainer = result;
            webRequestHandler.UseCookies = true;
            var client = new HttpClient(webRequestHandler);
            client.BaseAddress = new Uri("https://*********/");
            // get viewstate
            string viewstate;
            {
                var r = client.GetStringAsync("***/LoginPage.aspx");
                r.Wait();
                // see http://odetocode.com/articles/162.aspx
                viewstate = ExtractViewState(r.Result);
            }
            HttpContent loginData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("__VIEWSTATE", viewstate),
                    new KeyValuePair<string, string>("***$UserName", login),
                    new KeyValuePair<string, string>("***$Password", password),
                    new KeyValuePair<string, string>("***$LoginButton", "Log In"), // "value" of the HTML input element
                }
                );
            var postResult = client.PostAsync("****/LoginPage.aspx", loginData);
            postResult.Wait();
            postResult.Result.EnsureSuccessStatusCode();
            return result;
        }
