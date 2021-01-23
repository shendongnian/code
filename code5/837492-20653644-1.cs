    public static bool TryParse(string s, out MyClass result)
    {
        result = new MyClass();
        int prop;
        bool success = int.TryParse(s, out prop);
        if(success)
            result.Prop = prop;
        return success;
    }
