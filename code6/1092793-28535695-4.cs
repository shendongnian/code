    var serializer = new XmlSerializer(typeof(Root));
            var nameTable = new NameTable();
            var namespaceManager = new XmlNamespaceManager(nameTable);
            namespaceManager.AddNamespace("a", "http://custom/a");
            namespaceManager.AddNamespace("i", "http://custom/i");
            var parserContext = new XmlParserContext(null, namespaceManager, null, XmlSpace.None);
            var settings = new XmlReaderSettings()
            {
                ConformanceLevel = ConformanceLevel.Fragment
            };
            using(var fileStream=File.OpenRead(somePathToXmlFile))
            {
                using(var reader=XmlReader.Create(fileStream,settings,parserContext))
                {
                    var root = (Root)serializer.Deserialize(reader);
                }
            }
          
