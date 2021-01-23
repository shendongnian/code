    var xdoc = XDocument.Load(file);
    var menus = xdoc.Descendants("role")
                    .Where(r => (string)r.Attribute("name") == "admin")
                    .Elements("menu")
                    .Select(m => new Menu {
                        name = (string)m.Attribute("name"),
                        group = m.Elements("group")
                                    .Select(g => new Group { 
                                         name = (string)g.Attribute("name") 
                                    }).ToList()
                    }).ToList();
