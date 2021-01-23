    var xml = @"<Envelope>
            <Body>
                <Person>
                    <first>John</first>
                    <last>Smith</last>
                    <address>123</address>
                </Person>
            </Body>
        </Envelope>";
    var doc = XDocument.Parse(xml);
    foreach (XElement propertyOfPerson in doc.XPathSelectElements("/Envelope/Body/Person/*").ToList())
    {
    	propertyOfPerson.ReplaceWith(new XElement(propertyOfPerson.Name.LocalName));
    }
    Console.WriteLine(doc.ToString());
