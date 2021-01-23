    public class CsvRow
    {
        public string Column1 { get; set; }
        public bool Column2 { get; set; }
        public CsvRow(string column1, bool column2)
        {
            Column1 = column1;
            Column2 = column2;
        }
    }
    IEnumerable<CsvRow> rows = new [] {
        new CsvRow("value1", true),
        new CsvRow("value2", false)
    };
    using(var textWriter = new StreamWriter(@"C:\mypath\myfile.csv")
    {
        var writer = new CsvWriter(textWriter);
        writer.Configuration.Delimiter = ",";
        writer.WriteRecords(rows);
    }
