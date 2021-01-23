    private void MenuDeserializer()
    {
        Menu menu;
        string path = "MenuXML.xml";
    
        XmlSerializer serializer = new XmlSerializer(typeof(Menu));
    
        using(StreamReader reader = new StreamReader(path))
        {
            menu = (Menu)serializer.Deserialize(reader);
        }
    }
