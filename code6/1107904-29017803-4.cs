            var xml = GetXml(); // Load the XML.  (In my test code it's just a string literal.)
            var doc = XDocument.Parse(xml);
            var mapXml = doc.Root.Element("ArrayOfMapItem");
            var grantXml = doc.Root.Element("ArrayOfArrayOfGrant");
            if (mapXml != null)
            {
                var mapItems = mapXml.Deserialize<MapItem[]>();
                Debug.WriteLine(mapItems.GetXml()); // Two items deserialized successfully.
            }
            if (grantXml != null)
            {
                var grantItems = grantXml.Deserialize<Grant[][]>();
                Debug.WriteLine(grantItems.GetXml()); // Two arrays of arrays deserialized successfully.
            }
