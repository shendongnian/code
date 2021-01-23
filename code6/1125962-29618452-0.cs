    var globalVariables = (from cfg in _xElements.Descendants("Module")
                                                 .Elements("Variable")
                          select new Variable
                          {
                              Name = cfg.Attribute("Name").Value,
                              Enable = bool.Parse(cfg.Attribute("Enable").Value)
                          }).ToList(); 
