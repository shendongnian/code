    public Listings GetApi(string url)
    {
        ...
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                var jsonReader = new JsonTextReader(reader);
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Listings>(jsonReader);
            }
        ...
    }
