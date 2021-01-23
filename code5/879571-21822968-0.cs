    var xml = new XElement("Customer",
                    from prod in _customer
                    group prod by prod.Vendor into g
                    let vendor = g.Key
                    let items = g.SelectMany(x => x)
                    select
                        new XElement("Vendor",
                            new XAttribute("Value",g.Key.Vendor),
                            items.SelectMany(i => 
                                new [] {
                                     new XElement("CustomerBarcode", i.CustomerBarcode),
                                     new XElement("Description", i.Description),
                                     new XElement("UnitAmount", i.UnitAmount)
                                }
                            )
                        )
                    );
