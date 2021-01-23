    public static T Deserialize<T>(this string json) where T : new()
    {
         return json != null 
                        ? JsonConvert.DeserializeObject<T>(json)
                        : new T();
    }
    List<Person> persons = personsJson.Deserialize<List<string>>();
