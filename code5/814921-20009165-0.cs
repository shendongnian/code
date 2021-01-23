    public static T getSettingElementValue<T>(XDocument settings, string elementName) {
      return (T)Convert.ChangeType(settings.Element("Settings").Element(elementName).Value, typeof(T));	 	
    }
    void Main()
    {
        var xml = XDocument.Load(@"C:\abc\blah.xml");
        
        Console.WriteLine(getSettingElementValue<bool>(xml, "GardenWorld"));
    }
