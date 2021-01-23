        // Load the document
        var doc = XDocument.Parse(xml);
        var people = doc
            // Navigate to the list
            .Root.Elements("Result")
            .SelectMany(r => r.Elements())
            // Deserialize each element in the list as a KeyValuePair<string, Person>
            .Select(element =>
                {
                    var name = element.Name;
                    element.Name = typeof(Person).DefaultXmlElementName(); // Overwrite name with name used by serializer.
                    using (var reader = element.CreateReader())
                    {
                        var person = (Person)new XmlSerializer(typeof(Person)).Deserialize(reader);
                        return new KeyValuePair<string, Person>(name.LocalName, person);
                    }
                })
            .ToList();
