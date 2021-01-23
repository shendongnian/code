    public static class JsonSerializer
    {
            public static string Serialize<T>(T t) where T : class
            {
                return JsonConvert.SerializeObject(t);
            }
            public static T Deserialize<T>(string s) where T : class
            {
                return (T)JsonConvert.DeserializeObject(s, typeof(T));
            }
    }
