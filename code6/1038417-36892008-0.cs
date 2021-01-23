        protected const string UsernameFormFieldName = "username";
        protected const string PasswordFormFieldName = "password";
        protected const string DomainFormFieldName = "domain";
        const string CookieName = "AmberUser";
        const string baseAdress = "http://host:port";
        const string container = "/docushare";
        static Uri CookieUrl = new Uri(new Uri(baseAdress), container);
        const string root = "/xcm/v1/shadow/xcmAPI/root";
        const string FolderInfoUri = "/xcm/v1/shadow/object/{0}/xcmAPI/properties";
        const string ObjectVersion = "/xcm/v1/shadow/object/{0}/xcmAPI/version";
        const string ObjectToTest = "Collection-11";
        const string suffix = "?properties=title,mimetype";
        
        static void Main(string[] args)
        {
            var token = Authenticate();
            var requestUri = string.Format(container + FolderInfoUri, ObjectToTest) + suffix;
            var response = GetResult(token, requestUri);
            var content = response.Content.ReadAsStringAsync().Result;
        }
        private static string Authenticate()
        {
            const string AuthenticationPath = container + "/dsweb/ApplyLogin";
            
            var form = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>(UsernameFormFieldName, "login"),
                new KeyValuePair<string, string>(PasswordFormFieldName, "password"),
                new KeyValuePair<string, string>(DomainFormFieldName, "domain"),
            });
            string authToken = null;
            Execute((client, handler) =>
            {
                var task = client.PostAsync(AuthenticationPath, form, CancellationToken.None);
                var response = task.Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var cookie = handler.CookieContainer.GetCookies(CookieUrl);
                authToken = cookie[CookieName].Value;
            });
            return authToken;
        }
        private static void Execute(Action<HttpClient, HttpClientHandler> request)
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                handler.UseCookies = true;
                handler.CookieContainer = new CookieContainer();
                client.BaseAddress = new Uri(baseAdress);
                request(client, handler);
            }
        }
        private static HttpResponseMessage GetResult(string token, string uri)
        {
            HttpResponseMessage response = null;
            Execute((client, handler) =>
            {
                handler.CookieContainer.Add(
                    CookieUrl,
                    new Cookie(CookieName, token));
                var responseTask = client.GetAsync(uri);
                response = responseTask.Result;
            });
            return response;
        }
