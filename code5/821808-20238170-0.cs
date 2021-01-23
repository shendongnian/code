    XElement xml = XElement.Load(myXmlFile);
    string tabSpacer = "\t";
    foreach (var oneItem in xml.Elements("Item"))
    {
        //check if the "Name" element exists
        string name = oneItem.Element("Name") == null ? "" : oneItem.Element("Name").Value;
        //check if the "Type" element exists
        string type = oneItem.Element("Type") == null ? "" : oneItem.Element("Type").Value;
        Console.WriteLine(name + " - " + type);
    
        //check if the "Item" element contains an "Attributes" element
        if (oneItem.Element("Attributes") != null)
        {
            //assumes at most one "Attribtues" element
            foreach (var attribute in oneItem.Element("Attributes").Elements())
            {
                string role = attribute.Attribute("Role") == null ? "" : attribute.Attribute("Role").Value;
                Console.WriteLine(tabSpacer + attribute.Name + " " + role + ": " + attribute.Value);
            }
        }
    }
