    public static void saveSetting(String settingName, String newvalue)
    {
       XmlDocument xml = new XmlDocument();
    
       xml.Load(userSettingsFile);
    
       foreach (XmlElement element in xml.SelectNodes("Preferences"))
       {
     	 if(element.Name.Equals(settingName))
    	 {
    		element.InnerText = newvalue;
    		break;
    	 }
       }
    
       xml.Save(userSettingsFile);
    }
