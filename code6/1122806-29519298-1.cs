    private static Mapping<InputColumnMapping> ParseDestinationComponent(string ssisName,XElement source)
    {
        var table = source.XPathSelectElement("properties/property[@name='OpenRowset']").Value;
    
    
        var nonErrorOutput = source.XPathSelectElement("inputs").Elements().First(x => !((string)x.Attribute("name")).Contains("Error"));
    
        var inputColumns = nonErrorOutput.XPathSelectElement("inputColumns").Elements().Select(x =>
            new
            {
                lineageId = (int)x.Attribute("lineageId"),
                externalMetadataColumnId = (int)x.Attribute("externalMetadataColumnId")
            }).ToList();
    
        var externalMetadataColumns = nonErrorOutput.XPathSelectElement("externalMetadataColumns").Elements().Select(x =>
            new InputColumnMapping
            {
                Id = (int)x.Attribute("id"),
                Name = (string)x.Attribute("name")
            }).ToList();
        foreach (var externalMetadataColumn in externalMetadataColumns.ToList())
        {
            var inputMapping =
                inputColumns.FirstOrDefault(x => x.externalMetadataColumnId == externalMetadataColumn.Id);
            if (inputMapping == null)
            {
                Console.WriteLine("{0} | destination external column {1} with id {2} was not found in input mappings", ssisName, externalMetadataColumn.Name, externalMetadataColumn.Id);
                externalMetadataColumns.Remove(externalMetadataColumn);
                continue;
            }
            externalMetadataColumn.MappsToId = inputMapping.lineageId;
        }
        return new Mapping<InputColumnMapping>
        {
            TableName = NormalizeTableNames(table),
            Columns = externalMetadataColumns
        };
    }
