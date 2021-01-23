                if (reader.Read())
                {
                    var doc = XElement.Load(reader);
                    var newData =
                        new XElement("Holidays",
                            from data in doc.Elements("Holiday")
                            group data by (int)data.Element("Year") into groupedData
                            select new XElement("Group",
                                new XAttribute("ID", groupedData.Key),
                                from g in groupedData
                                select new XElement("Holiday", new XAttribute("ID", g.Element("Name").Value), g.Element("Date"))
                            )
                        );
                    var newXml = newData.ToString();
                    Debug.WriteLine(newXml);
                }
