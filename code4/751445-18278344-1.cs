    public static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
     var pSettings = (string)GetPropValue(Properties.Settings.Default, settingName);
