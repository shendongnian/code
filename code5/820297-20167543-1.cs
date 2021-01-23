    DataTable tblCSV = new DataTable("CSV");
    var fileInfo = new FileInfo(fullPath);
    var encoding = Encoding.Default;
    int headerIndex = 0;
    using (var reader = new System.IO.StreamReader(fileInfo.FullName, encoding))
    {
        for (int i = 0; i < headerIndex; i++)
            reader.ReadLine(); // skip all lines but header+data
        Char quotingCharacter = '"';
        Char escapeCharacter = quotingCharacter;
        Char commentCharacter = '\0'; // none
        Char delimiter = ',';
        using (var csv = new CsvReader(reader, true, delimiter, quotingCharacter, escapeCharacter, commentCharacter, ValueTrimmingOptions.All))
        {
            csv.MissingFieldAction = MissingFieldAction.ParseError;
            csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
            csv.ParseError += csv_ParseError;  // the method that handles this error
            csv.SkipEmptyLines = true;
            try
            {
                // load into DataTable
                tblCSV.Load(csv, LoadOption.OverwriteChanges, csvTable_FillError); // csvTable_FillError-> the method that handles this error
            } catch (Exception ex)
            {
                // logging 
                throw;
            }
        }
    }
    void csv_ParseError(object sender, ParseErrorEventArgs e)
    {
        // if the error is that a field is missing, then skip to next line
        if (e.Error is MissingFieldCsvException)
        {
            //Log.Write(e.Error, "--MISSING FIELD ERROR OCCURRED!" + Environment.NewLine);
            e.Action = ParseErrorAction.AdvanceToNextLine;
        }
        else if (e.Error is MalformedCsvException)
        {
            //Log.Write(e.Error, "--MALFORMED CSV ERROR OCCURRED!" + Environment.NewLine);
            e.Action = ParseErrorAction.AdvanceToNextLine;
        }
        else
        {
            //Log.Write(e.Error, "--UNKNOWN PARSE ERROR OCCURRED!" + Environment.NewLine);
            e.Action = ParseErrorAction.AdvanceToNextLine;
        }
        // log
    }
    void csvTable_FillError(object sender, FillErrorEventArgs e)
    {
        // You can use the e.Errors value to determine exactly what went wrong.
        if (e.Errors.GetType() == typeof(System.FormatException))
        {
            // log
        }
        // Setting e.Continue to True tells the Load
        // method to continue trying. Setting it to False
        // indicates that an error has occurred, and the 
        // Load method raises the exception that got you here.
        e.Continue = true;
        string errors = string.Join(Environment.NewLine, e.Errors);
        // log
    }
