    enum Columns
    {
        Label,
        Total,
        Copied,
        Skipped,
        Mismatch,
        Failed,
        Extra
    }
    ...
    string[] rowData = content.Split('\t');
    Console.WriteLine(rowData[(int)Columns.Total]);
}
