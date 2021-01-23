        public async static Task<IDictionary<string, string>> GetBodyParameters(this IOwinRequest request)
        {
            var dictionary = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            if (request.ContentType != "application/json")
            {
                var formCollectionTask = await request.ReadFormAsync();
                foreach (var pair in formCollectionTask)
                {
                    var value = GetJoinedValue(pair.Value);
                    dictionary.Add(pair.Key, value);
                }
            }
            else
            {
                using (var stream = new MemoryStream())
                {
                    byte[] buffer = new byte[2048]; // read in chunks of 2KB
                    int bytesRead;
                    while ((bytesRead = request.Body.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                    var result = Encoding.UTF8.GetString(stream.ToArray());
                    // TODO: do something with the result
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    foreach(var pair in dict)
                    {
                        string value = (pair.Value is string) ? Convert.ToString(pair.Value) : JsonConvert.SerializeObject(pair.Value);
                        dictionary.Add(pair.Key, value);
                    }
                }
            }
            return dictionary;
        }
        private static string GetJoinedValue(string[] value)
        {
            if (value != null)
                return string.Join(",", value);
            return null;
        }
