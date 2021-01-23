    public static Dictionary<string, string> myFunction()
    {
        try
        {
            Dictionary<string, string> dict;
            dict = new Dictionary<string, string>();
            // do something with dict
            return dict;
        }
        catch (Exception ex)
        {
            // handle ex
        }
        return null;
    }
