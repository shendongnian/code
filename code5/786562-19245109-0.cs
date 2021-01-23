    var xlContent = new XElement("Content", from row in dt.AsEnumerable()
                                                        select new XElement("Row", new XElement("Column1", row["Column1"]),
                                                                                   new XElement("Column2", row["Column2"]),
                                                                                   new XElement("Column3", row["Column3"]),
                                                                                   new XElement("Column4", row["Column4"]))).ToString();
