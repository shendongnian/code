    private static RemoteMappingFile ParseDtsx(string ssisName)
    {
        var xml = XDocument.Load(@"ssis/"+ssisName);
    
        if (xml.Root == null)
        {
            throw new Exception("Root is null");
        }
        var mappings = new List<RemoteMapping>();
    
        XNamespace ns = "www.microsoft.com/SqlServer/Dts";
        XmlNamespaceManager man = new XmlNamespaceManager(new NameTable());
        man.AddNamespace("DTS", "www.microsoft.com/SqlServer/Dts");
        var executables = xml.Root.Descendants(ns + "Executable").Select(x => x).ToList();
        foreach (var executable in executables)
        {
            var components = executable.Descendants(ns + "ObjectData").First().XPathSelectElement("pipeline/components").Elements().ToList();
            if (components.Count != 2)
            {
                Console.WriteLine("{0} | WARN - 2 components expected. Found {1} with names: {2}", ssisName, components.Count, string.Join(",",components.Select(x=>((string)x.Attribute("name"))).ToList()));
            }
            var source = components.First(x => ((string)x.Attribute("name")).Contains("Source"));
            var destination = components.First(x => ((string)x.Attribute("name")).Contains("Destination"));
            var sourceMapping = ParseSourceComponent(source);
            var destinationMapping = ParseDestinationComponent(ssisName,destination);
            var remoteMapping = new RemoteMapping
            {
                TableNames = new Column { Source = sourceMapping.TableName, Destination = destinationMapping.TableName },
                Columns = new List<Column>()
            };
            foreach (var sourceItem in sourceMapping.Columns)
            {
                var foundMatchingDestinationColumn =
                    destinationMapping.Columns.FirstOrDefault(x => x.MappsToId == sourceItem.Id);
                if (foundMatchingDestinationColumn == null)
                {
                    Console.WriteLine("{0} | input mapping {1} with id {2} was not found in destination mappings",
                        ssisName, sourceItem.Name, sourceItem.Id);
                    continue;
                }
                remoteMapping.Columns.Add(new Column
                {
                    Destination = foundMatchingDestinationColumn.Name,
                    Source = sourceItem.Name
                });
            }
            mappings.Add(remoteMapping);
        }
    
        return new RemoteMappingFile
        {
            RemoteMappings = mappings,
            SSISName = ssisName
        };
    }
