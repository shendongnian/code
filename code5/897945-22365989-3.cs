     using System.IO;
     using LumenWorks.Framework.IO.Csv;
     List<string> output = new List<string>();
    // open the file "data.csv" which is a CSV file with headers
    using (CsvReader csv =
           new CsvReader(new StreamReader("data.csv"), true))
    {
        int fieldCount = csv.FieldCount;
        string[] headers = csv.GetFieldHeaders();
        while (csv.ReadNextRecord())
        {
            output.Add(String.Join("\t", csv.NotSureWhatThisPropertyNameShouldBe));
        }
    }
