    public static class Helpers
    {
        public static T Deserialize<T>(this HttpResponseMessage response) where T : class
        {
            var stream = response.Content.ReadAsStreamAsync().Result;
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
