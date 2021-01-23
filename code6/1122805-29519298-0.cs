    private static Mapping<ColumnMapping> ParseSourceComponent(XElement source)
    {
        var table = source.XPathSelectElement("properties/property[@name='OpenRowset']").Value;
    
    
        var nonErrorOutput = source.XPathSelectElement("outputs").Elements().First(x => !((string)x.Attribute("name")).Contains("Error"));
    
        var outputColumns = nonErrorOutput.XPathSelectElement("outputColumns").Elements().Select(x => 
            new ColumnMapping
            {
                Id = (int)x.Attribute("id"),
                Name = (string)x.Attribute("name")
            }).ToList();
    
        return new Mapping<ColumnMapping>
        {
            TableName = NormalizeTableNames(table),
            Columns = outputColumns
        };
    }
    static readonly Regex tableNameRegex = new Regex("\\[dbo\\]\\.\\[(.*)\\]");
    private static string NormalizeTableNames(string rawTableName)
    {
        var matches = tableNameRegex.Match(rawTableName);
        if (matches.Success) 
            return matches.Groups[1].Value;
        return rawTableName;
                
    }
