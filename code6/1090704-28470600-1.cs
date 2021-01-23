    class Program
        {
           
    
            static void Main(string[] args)
            {
                //UpdateSetting("language", "English");
                UpdateAppSettings("card", "drink", "water");
            }
    
            public static void UpdateAppSettings(string OldKeyName, string KeyName, string KeyValue)
            {
                XmlDocument XmlDoc = new XmlDocument();
    
                XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    
                foreach (XmlElement xElement in XmlDoc.DocumentElement)
                {
                    if (xElement.Name == "appSettings")
                    {
    
                        foreach (XmlNode xNode in xElement.ChildNodes)
                        {
                            if (xNode.Attributes[0].Value == OldKeyName)
                            {
                                xNode.Attributes[0].Value = KeyName;
                                xNode.Attributes[1].Value = KeyValue;
                            }
                        }
                    }
                }
                XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            }
    }
