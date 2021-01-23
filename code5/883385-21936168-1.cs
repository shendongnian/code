    private static DataTable FixedWidthTxtRead(string filename, int[] fieldWidths)
    {
        string[] fields;
        DataTable dtable = new DataTable();
        ArrayList aList;
        using (TextFieldParser tfp = new TextFieldParser(filename))
        {
            tfp.TextFieldType = FieldType.FixedWidth;
            tfp.SetFieldWidths(fieldWidths);
            for (int col = 1; col <= fieldWidths.length; ++col)
                dtable.Columns.Add("COL" + col);
            while (!tfp.EndOfData)
            {
                fields = tfp.ReadFields();
                aList = new ArrayList();
                for (int i = 0; i < fields.Length; ++i)
                    aList.Add(fields[i] as string);
                if (dtable.Columns.Count == aList.Count) dtable.Rows.Add(aList.ToArray());
            }
        }
        return dtable;
    }
