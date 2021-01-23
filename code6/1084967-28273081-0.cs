    //this counter lets you count number of business cards
    int iCounter = 1;
    //Namespace associated with your businessCards
    XNamespace xn = "http://ocrsdk.com/schema/recognizedBusinessCard-1.0.xsd";
    //Dictionary containing business cards with fields as their values.
    var lists = xd.Elements(xn + "businessCard").ToDictionary(key => iCounter++, bus => bus.Elements(xn + "field").
                ToDictionary(key => key.Attribute("type").Value, value => value.Element(xn + "value").Value));
