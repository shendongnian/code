    System.Data.DataTable dt = new System.Data.DataTable();
    dt.Columns.Add("Col1", typeof(int));
    for (int index = 0; index < 10; index++)
    {
         System.Data.DataRow row = dt.NewRow();
         row.BeginEdit();
         row["Col1"] = 10;
         row.AcceptChanges();
         dt.Rows.Add(row);
    }
    dt.AcceptChanges();
