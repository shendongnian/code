    DataTable data = new DataTable("CSV");
    var fileInfo = new System.IO.FileInfo("Path");
    using (var reader = new System.IO.StreamReader(fileInfo.FullName, Encoding.Default))
    {
        // use  reader.ReadLine(); to skip all lines but header+data
        Char quotingCharacter = '\0';//'"';
        Char escapeCharacter = quotingCharacter;
        using (var csv = new CsvReader(reader, true, '\t', quotingCharacter, escapeCharacter, '\0', ValueTrimmingOptions.All))
        {
            csv.MissingFieldAction = MissingFieldAction.ParseError;
            csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
            //csv.ParseError += csv_ParseError;
            csv.SkipEmptyLines = true;
            // load into DataTable
            data.Load(csv, LoadOption.OverwriteChanges, csvTable_FillError);
        }
    }
