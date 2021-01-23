                XDocument xdoc = XDocument.Load("path");
                IEnumerable<XElement> nodes = (from p in xdoc.Descendants()
                                               where p.Name.LocalName == "FirstName"
                                               select p).Elements();
    
                foreach (XElement nodeFirstName in nodes)
                {
                    foreach (XElement parts in nodeFirstName.Elements())
                    {
                      string strExtracted = parts.Name.LocalName + " " + parts.Value;
                    }
                }
