    string name = "";
    scripData = ScrpHldNode.Descendants(ns + "Scrp")
                           .Select(scrp => {
                                var currentName = (string)scrp.Element(ns + "Name");
                                if (!String.IsNullOrEmpty(currentName))
                                    name = currentName;
                                return new ScripTbl {
                                    ScripShare = name
                                    // ...
                                };
                           });
