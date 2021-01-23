        foreach (var XSDsection in sections)
        {
            //Get Section Element;
            string SchemaSchedule = XSDsection.Attribute("name").Value;
            var SchemaSectionSchedule = XSDsection.Element(prefix + "complexType")
                                .Element(prefix + "sequence")
                                .Elements(prefix + "element");
            foreach (var schemaSection in SchemaSectionSchedule)
            {
                //Get child element;
                string schemaElement = schemaSection.Attribute("name").Value;
                var XMLsectionSchedule = xDoc.Descendants(SchemaSchedule);
                foreach (XElement element in xDoc.Element(SchemaSchedule).Descendants())
                {
                    string value = element.Value;       //returns value of next element;
                    string el = element.ToString();     //returns the next element and value from xml file;
                    if(value == myDesiredValue)
                    {
                        return element; // if you want the element, return it
                    }
                }
            }
        }
