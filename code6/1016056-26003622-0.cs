    string csv = "25,4.6,4%,32,\"text1\",\"text2, text3\",\"text4,,t\"";
    var reader = new StringReader(csv);
    List<string[]> allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader))
    {
        parser.Delimiters = new string[] { "," };
        parser.TrimWhiteSpace = true;
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] fields;
        while ((fields = parser.ReadFields()) != null)
        {
            allLineFields.Add(fields);
        }
    }
    foreach (string[] arr in allLineFields)
        Console.WriteLine(string.Join("|", arr));
