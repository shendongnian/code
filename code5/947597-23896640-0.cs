            XmlDocument xml = new XmlDocument();
            xml.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                <shiporder orderid=""889923"">
                    <orderperson>John Smith</orderperson>
                    <shipto>
                        <name>Ola Nordmann</name>
                        <address>Langgt 23</address>
                        <city>4000 Stavanger</city>
                        <country>Norway</country>
                    </shipto>
                </shiporder>");
            xml.Schemas.Add(null, "schema.xsd");
            xml.Validate((sender, args) =>
            {
                switch (args.Severity)
                {
                    case XmlSeverityType.Error:
                        Console.WriteLine("XML is invalid: {0}", args.Exception);
                        break;
                    case XmlSeverityType.Warning:
                        // handle warning
                        ;
                        break;
                }
            });
