    public IEnumerable<TResult> ReadJson<TResult>(Stream stream)
    {
        var serializer = new JsonSerializer();
        
        using (var reader = new StreamReader(stream))
        using (var jsonReader = new JsonTextReader(reader))
        {
            jsonReader.SupportMultipleContent = true;
            
            while (jsonReader.Read())
            {
                yield return serializer.Deserialize<TResult>(jsonReader);
            }
        }
    }
