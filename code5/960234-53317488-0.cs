        public static string GetPagePhantomJs(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.ExpectContinue = false;
                var pageRequestJson = new System.Net.Http.StringContent(@"{'url':'" + url + "','renderType':'html','outputAsJson':false }");
                var response = client.PostAsync("https://PhantomJsCloud.com/api/browser/v2/{YOUT_API_KEY}/", pageRequestJson).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
