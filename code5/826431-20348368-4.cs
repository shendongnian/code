    var xdoc = XDocument.Parse(xml_string);
    var utility = xdoc.Root.Element("Utility");
    
    var data = new getPowerBillRateData();
    data.UtilityId = (string)utility.Attribute("UtilityId");
    data.UtilityName = (string)utility.Attribute("UtilityName");
    var rate = utility.Element("Rate");
    data.RateId = (string)rate.Attribute("Id");
    data.RateName = (string)rate.Attribute("Name");
    data.RateSector = (string)rate.Attribute("Sector");
    //etc
