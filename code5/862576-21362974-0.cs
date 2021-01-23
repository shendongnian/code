     var xml = new XElement(
                            "array",
                            data.Select(d =>
                            new XElement("dict",ObjectContext.GetObjectType(d.GetType   ()).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                                                    
                                                    .Select(
                                                     p => new[] { 
                                                     new XElement("key",p.Name), 
                                                        new XElement("string", p.GetValue(d, null)) }
                                                            )
                                                )
                                     ));
