        private void LoadData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("http://somelinks").Result;
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
                Console.ReadLine();
            }
        }
