    System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
    settings.NewLineOnAttributes = false;
    settings.Indent = true;
    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create("output.xml", settings))
    {
        writer.WriteStartDocument();
    
        int[] IS_CONTAINER = new int[] { 1, 1, 0, 0, 1, 1 };
        string[] TAG_NAME = new string[]{ "x", "y", "a", "b", "/y", "/x"};
        string[] TAG_VALUE = new string[]{ null, null, "cc", "kk", "/y", "/x"};
    
        for (int i = 0; i <= TAG_NAME.Length - 1; i++)
        {
            if (!TAG_NAME[i].Contains("/"))
            {
                writer.WriteStartElement(TAG_NAME[i]);
                if(TAG_NAME[i] != null) writer.WriteValue(TAG_VALUE[i]);
            }
    
            if(IS_CONTAINER[i] == 0 || TAG_NAME.Contains("/")) writer.WriteEndElement();
        }
    
        writer.WriteEndDocument();
    }
