    public static async Task<string> GetTwitterList(string bearerToken)
        {
            WebRequest request = WebRequest.Create("https://api.twitter.com/1.1/lists/statuses.json?slug=odyssee&owner_screen_name=dieVanDeIlias");
            string result = "";
            request.Method = "GET";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", bearerToken));
            request.Timeout = Timeout.Infinite;
                
            WebResponse response = await request.GetResponseAsync();
            Encoding encoder = System.Text.Encoding.GetEncoding("utf-8");
            string contentLength = response.Headers.Get("Content-Length");
            int contentLengthInt = Convert.ToInt32(contentLength);
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoder))
            {
                while (sr.Peek() >= 0)
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
