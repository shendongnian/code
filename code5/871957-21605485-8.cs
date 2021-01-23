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
    }
