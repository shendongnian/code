    XElement xe = XElement.Load(xml);
    
    xe
    .Elements("Employee")
    .Select
    (
        x=>
        new 
        {
            ID = x.Element("ID").Value,
            Addresses = x.Elements("Address")
                        .Select
                        (
                            z=>
                            new 
                            {
                                City = z.Element("City").Value,
                                CreatedOn = z.Element("CreatedOn").Value
                            }
                        ).ToList()
        }
    );
