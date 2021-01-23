            XDocument doc = XDocument.Load("Spejder.xml");
            foreach (var item in doc.Descendants("Spejder"))
            {
                var xElement = item.Element("Navn");
                if (xElement != null)
                {
                    string currentName = xElement.Value;
                    if (currentName == inputName)
                    {
                        var newChildelement = new XElement("tilmeld", "new child");
                        
                        var subs = item.Element("tilmeld");
                        if (subs != null)
                        {
                            subs.Add(newChildelement);
                        }
                        else
                        {
                            XNode node = new XElement("tilmeld", newChildelement);
                            item.Add(node);
                        }
                    }
                }
            }
            doc.Save("Spejder.xml");
