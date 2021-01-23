    internal static LoadIndividualItem(XElement xelement)
    {
        XElement element = ; //you need to pass the document as an Xelement somehow
    
        foreach (XElement child in element.Elements())
                    {
                        string elementName = child.Name.ToString();
        
                        if (string.Compare(elementName, "item", true) == 0)
                        {
                            string name = child.Attribute(XName.Get("name"));
                            // Do something with this string
        
                            string name = child.Attribute(XName.Get("url"));
                            // Do something with this string\
                        }
                    }
    }
