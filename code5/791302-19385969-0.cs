    var d = xml.Descendants("Tactics")
               .GroupBy(e=>e.Parent.Name.LocalName == "Product" ?
                           e.Parent.Element("ProductId").Value : "")
               .ToDictionary(x => x.Key, x => ((XElement)x.First())
                                         .Descendants("Tactic").ToList()
                                         .OrderByDescending (y=>(DateTime)y.Element("VF")));
