                  Name = p.Attribute("Name").Value,
                  Type = (EnvironmentType)Enum.Parse(typeof
                 (EnvironmentType), p.Attribute("Type").Value, true),
                  DataCenters = p.Elements("DataCenter").Select(
                   dc => new DataCenter { 
                                          Name = dc.Attribute("Name").Value,                                      DeployEnvironmentName = dc.Attribute         
                                         ("DeployEnvironmentName").Value                                      })
                                    });
                                     ^^^
                });
      
