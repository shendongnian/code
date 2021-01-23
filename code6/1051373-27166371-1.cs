    public static T Deserialize<T>(string file)
    {
        try
        {
            ...
        }
        catch (Exception e)
        {
            Log("xml", exception: e, param: file, param2: typeof(T));
        }
        return default(T);
