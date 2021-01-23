    public static bool IsEnabled(string sName)
    {
        if (TenderTypes.strings[sName] != "0")
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
