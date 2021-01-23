    public static bool TryParse(string s, ref MyClass result)
    {
        if(result == null)
            throw new ArgumentNullException("result");
        int prop;
        bool success = int.TryParse(s, out prop);
        if (success)
            result.Prop = prop;
        return success;
    }
