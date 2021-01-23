        tbl.Rows[0].Delete();
        DataRow r = tbl.Rows[0];
        foreach(DataColumn c in tbl.Columns)
        {
            tbl.Columns[c.ColumnName].ColumnName = r[c.ColumnName].ToString();
         }
         tbl.Rows[0].Delete();
