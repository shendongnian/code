    private static DataTable FixedWidthDiliminatedTxtRead(int[] fieldWidthArray)
    {
        string[] fields;
        StringBuilder sb = new StringBuilder();
        List<StringBuilder> lst = new List<StringBuilder>();
        DataTable dtable = new DataTable();
        ArrayList aList;
    
        using (TextFieldParser tfp = new TextFieldParser(testOCC))
        {
            tfp.TextFieldType = FieldType.FixedWidth;
            tfp.SetFieldWidths(fieldWidthArray);
            for (int col = 1; col < 13; ++col)
                dtable.Columns.Add("COL" + col);
            while (!tfp.EndOfData)
            {
                fields = tfp.ReadFields();
                aList = new ArrayList();
                for (int i = 0; i < fields.Length; ++i)
                    aList.Add(fields[i] as string);
                if (dtable.Columns.Count == aList.Count)
    
                dtable.Rows.Add(aList.ToArray());
    
    
            }
        }
        return dtable;
    }
