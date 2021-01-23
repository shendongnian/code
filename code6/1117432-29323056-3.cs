        public List<string> getZipCodesWithinRadius(string zipCode, string radius)
        {
            List<string> zipCodes = new List<string>();
            string apiKey = @"---REMOVED FROM ANSWER---";
            string apiFormat = @"radius.json";
            string baseUrl = @"http://www.zipcodeapi.com/rest/";
            string url = baseUrl + apiKey + @"/" + apiFormat + @"/" + zipCode + @"/" + radius + @"/mile";
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var root = new JsonSerializer().Deserialize<RootObject>(jsonReader);
                if (root != null)
                {
                    foreach (ZipCode z in root.zip_codes)
                    {
                        zipCodes.Add(z.city);
                    }
                }
            }
            return zipCodes;
        }
