    public RootObject objFromApi_idToName(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("<your uri here>");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("<uri extention here>");
                if (response.IsSuccessStatusCode)
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<List<your model class here>>(jsonStr);
                    return deserializedResponse;
            }
        }
