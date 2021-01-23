    ds = obj.openDataset(sql, Session["SchoolCode"].ToString());
    DataTable dtOriginalTable = ds.Tables[0];
    DataTable dtFinalTable = new DataTable();
    foreach (DataColumn dc in dtOriginalTable.Columns)
    {
    dtFinalTable.Columns.Add(dc.ColumnName);
    }
    foreach (DataColumn dc in dtFinalTable.Columns)
    {
               if (dc.ColumnName == "status")
                   dc.DataType = System.Type.GetType("System.Boolean");
    }
