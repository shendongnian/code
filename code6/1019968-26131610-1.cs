    static class JsonHelper
    {
        public static string Serialize(object target, string propertyToIgnore)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new IgnorePropertyResolver(target.GetType(), propertyToIgnore);
            return JsonConvert.SerializeObject(target, settings);
        }
        public static string Hash(string json)
        {
            using (var sha = new SHA1Managed())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(json)));
            }
        }
    }
