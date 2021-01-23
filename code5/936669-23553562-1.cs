    xDoc.Descendants("Customer")
                .SelectMany(
                    x =>
                        x.Elements("Facility")
                            .Where(
                                f =>
                                    (DateTime) f.Element("FacilityExpiryDate") >
                                    (DateTime) x.Element("CurrentBusinessDate")));
