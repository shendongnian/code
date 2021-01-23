    // This for loop adds the column names to the first row of the Excel document.
    for (ci = 0; ci < ds.Tables[0].Columns.Count; ci++)
        xlWorkSheet.Cells[1, ci + 1] = ds.Tables[0].Columns[ci].ColumnName;
    // This for loop populates the excel document with values.
    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
        for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
        {
            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
            // +2 because we already inserted the header row.
            xlWorkSheet.Cells[i + 2, j + 1] = data;
        }
    }
