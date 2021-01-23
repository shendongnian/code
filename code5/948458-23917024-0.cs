    var root = new XDocument("Root", 
         new XElement("Customers"),
            new XElement("Customer",
               new XAttribute("CustomerID", "HELLO"),
               new XElement("CompanyName", this.CompanyName),
               new XElement("ContactName", this.ContactName),
               new XElement("ContactTitle", this.ContactTitle),
               new XElement("Phone", this.Phone),
               new XElement("FullAddress", 
                  new XElement("Address", "..."),
                  new XElement("Region", "...")
    
               )
            )
        );
