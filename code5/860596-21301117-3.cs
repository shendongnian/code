    public static string GetEnumName(this Preferences preferences)
    {
        var memInfo = typeof(Preferences).GetMember(preferences.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumNameAttribute), false);
            if (attrs != null && attrs.Length > 0)
                return ((EnumNameAttribute)attrs[0]).Name;
        }
        throw new Exception("No enum name attribute defined");
    
    }
