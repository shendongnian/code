    string[] lines = str.Substring(str.IndexOf("\n")).Split('\n');// split it to lines;
    List<line> tblLines = new List<line>();
    foreach(string curr in lines)
    {
        tblLines.Add(new line(curr);
    }
