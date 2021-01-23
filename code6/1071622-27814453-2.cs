    using System.Xml.Linq; // required namespace 
    XDocument xmlDoc = new XDocument();
    XElement xElm = new XElement("Languages",
                        from l in lang.Split(',')
                        select new XElement("lang", new XAttribute("Name", l)                
                        )
                    );
    xmlDoc.Add(xElm);
