    private static DataTable CompareTwoDataTable(DataTable table1, DataTable table2)
    {
        DataTable table3 = new DataTable();
        DataRow dr = null;
        string filterExp = string.Empty;
        for (int i = 0; i < table1.Rows.Count; i++)
        {
            string col = table1.Rows[i]["Par Name"].ToString();
            if (table2.Columns.Contains(col))
            {
                if (!table3.Columns.Contains(col))
                {
                    table3.Columns.Add(col, typeof(double));
                    filterExp = filterExp + col + " asc ,";
                }
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    if (table3.Rows.Count != table2.Rows.Count)
                    {
                        dr = table3.NewRow();
                        table3.Rows.Add(dr);
                    }
                    table3.Rows[j][col] = (table2.Rows[j][col]);
                }
            }
        }
        DataTable resultDt = table3.Clone();
        for (int m = 0; m < table3.Columns.Count; m++)
        {
            DataView dv = new DataView(table3);
            dv.Sort = filterExp.Split(',')[m];
            table3 = dv.ToTable();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                if (resultDt.Rows.Count != table3.Rows.Count)
                {
                    resultDt.Rows.Add();
                }
                resultDt.Rows[i][m] = table3.Rows[i][m];
            }
        }
        return resultDt;
    }
