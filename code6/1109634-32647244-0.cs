    static async void getHttpClient()
        {
            string mUrl = "http://192.168.1.111/method";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(mURL))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                if (result != null)
                {
                    Console.WriteLine(result);
                } else
                {
                     //
                     // ERROR
                     // 
                }
            }
        }
