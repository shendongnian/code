    public static bool TryParseJson<T>(this string obj, out T result)
    {
        try
        {
            result = JsonConvert.DeserializeObject<T>(obj);
            return true;
        }
        catch (JsonSerializationException ex)
        {
            result = default(T);
            return false;
        }
    }
