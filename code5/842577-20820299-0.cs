    private Dictionary<char, UInt32> ColumnStyles(Worksheet worksheet)
    {
        Columns columns = worksheet.GetFirstChild<Columns>();
        char colIndex = 'A';
        for (Column column = (Column)columns.FirstChild; column != null; column = (Column)column.NextSibling())
        {
            UInt32 Min   = column.Min.Value;
            UInt32 Max   = column.Max.Value;
            UInt32 Style = column.Style.Value;
            for (int i = 1; i <= Max - Min + 1; i++)
            {
                StyleOf[colIndex++] = Style;
            }
        }
        return StyleOf;
    }
