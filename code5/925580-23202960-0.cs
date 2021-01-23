    try
    {
        if (File.Exists("D://my.bin"))
        {
           ...
           return deserializedObject;
        }
    }
    catch
    {
    }
    return null; // Or return an empty dictionary with:
                 // return new Dictionary<int, Question>();
