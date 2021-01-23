    using(var bcp = new SqlBulkCopy())
    using(var reader = ObjectReader.Create(ParseFile(path)))
    {
        bcp.DestinationTable = "MyLog";
        bcp.WriteToServer(reader);    
    }
    ...
    static IEnumerable<LogRow> ParseFile(string path)
    {
        using(var reader = File.OpenText(path))
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
                yield return new LogRow {
                    // TODO: populate the row from line here
                };
            }
        }
    }
    ...
    public sealed class LogRow {
        /* define your schema here */
    }
