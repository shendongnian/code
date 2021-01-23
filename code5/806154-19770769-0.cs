    public static string GetString(Animal animal)
    {
        var result = "";
        var serialized = JsonConvert.SerializeObject(animal);
        var dict = JsonConvert.DeserializeObject<IDictionary<string, string>>(serialized);
        foreach (var pair in dict)
        {
            if (!string.IsNullOrEmpty(result))
                result += "&";
            result += string.Format("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value.ToString()));
        }
        return result;
    }
