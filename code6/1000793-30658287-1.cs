    string CSVFilePathName = @file.DirectoryName + "\\" + file.Name;
    string[] Lines = File.ReadAllLines(CSVFilePathName);
    string[] Fields;
    Fields = Lines[0].Split(new char[] { ',' });
    int Cols = Fields.GetLength(0);
    DataTable dt = new DataTable();
    //1st row must be column names; force lower case to ensure matching later on.
    for (int i = 0; i < Cols; i++)
        dt.Columns.Add(Fields[i].ToLower(), typeof(string));
    DataRow Row;
    for (int i = 1; i < Lines.GetLength(0); i++)
    {
        Fields = Lines[i].Split(new char[] { ',' });
        Row = dt.NewRow();
        for (int f = 0; f < Cols; f++)
            Row[f] = Fields[f];
        dt.Rows.Add(Row);
    }
