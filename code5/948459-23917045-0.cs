    var xdoc = new XDocument(
        new XElement("Root",
            new XElement("Customers",
                new XElement("Customer",
                    new XAttribute("CustomerID", "HELLO"),
                    new XElement("CompanyName", "Great Lakes Food Market"),
                    new XElement("ContactName", "Howard Snyder"),
                    new XElement("ContactTitle", "Marketing Managerr"),
                    new XElement("Phone", "(503) 555-7555"),
                    new XElement("FullAddress",
                        new XElement("Address", "2732 Baker Blvd."),
                        new XElement("City", "Eugene"),
                        new XElement("Region", "OR")
                        new XElement("PostalCode", "97403")
                        new XElement("Country", "USA")
                        )
                    )
            )));
