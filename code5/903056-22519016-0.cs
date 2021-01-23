    public static void saveSetting(String settingName, String newvalue)
    {
        var xmlDocument = XDocument.Load("path");
        var element = xmlDocument.Descendants(settingName).FirstOrDefault();
        if (element != null) element.Value = newvalue;
        xmlDocument.Save("path");
    }
