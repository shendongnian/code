       public static class WebRequestExtensions
        {
            public static async Task<string> GetContentAsync(this WebRequest request)
            {
                WebResponse response = await request.GetResponseAsync();
                using (var s = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
