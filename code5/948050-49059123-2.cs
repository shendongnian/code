    public static bool TryParseJson<T>(this string obj, out T result)
    {
        try
        {
            // Validate missing fields of object
            JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.MissingMemberHandling = MissingMemberHandling.Error;
            result = JsonConvert.DeserializeObject<T>(obj);
            return true;
        }
        catch (JsonSerializationException ex)
        {
            result = default(T);
            return false;
        }
    }
