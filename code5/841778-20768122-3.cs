    public static bool IsEnabled(string sName)
    {
        var type = typeof(TenderTypes);
        var field = type.GetField(sName, BindingFlags.Static);
        if (field.GetValue(null) != "0")
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
