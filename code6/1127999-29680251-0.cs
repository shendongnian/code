    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
    {
        reader.ReadToFollowing("choicesConfig");
    
        if (reader.ReadToDescendant("element"))
        {
            do
            {
                Console.WriteLine("Text: {0}", reader.GetAttribute("text"));
            } while (reader.ReadToNextSibling("element"));
        }
    }
