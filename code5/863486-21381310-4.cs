    var tblCSV = new DataTable();
    using (System.Net.WebResponse tmpRes = tmpReq.GetResponse())
    using (System.IO.Stream tmpStream = tmpRes.GetResponseStream())
    using (System.IO.TextReader tmpReader = new System.IO.StreamReader(tmpStream))
    using (var csv = new CsvReader(tmpReader, true, '\t', '"', '\0', '\0', ValueTrimmingOptions.All))
    {
        csv.MissingFieldAction = MissingFieldAction.ParseError;
        csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
        csv.ParseError += csv_ParseError;
        csv.SkipEmptyLines = true;
        // load into DataTable
        tblCSV.Load(csv, LoadOption.OverwriteChanges, csvTable_FillError);
    } 
