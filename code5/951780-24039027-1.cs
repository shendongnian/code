        private static async Task<TReturn> PostAsync<TReturn>(string postUri, object data)
        {
            TReturn ret = default(TReturn);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.sendgrid.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", credentials.UserName, credentials.Password))));
                HttpResponseMessage response = await client.PostAsync(postUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string t = await response.Content.ReadAsStringAsync();
                    ret = JsonConvert.DeserializeObject<TReturn>(t);
                }
            }
            return ret;
        }
