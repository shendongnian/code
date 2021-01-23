    DataTable mergeDataTables(DataTable dt1, DataTable dt2)
    {
        if(dt1.Rows.Count != dt2.Rows.Count ) throw new Exception();
        var dtResult = new DataTable();
        //add new columns
        foreach (DataColumn col in dt1.Columns)
            dtResult.Columns.Add(col.ColumnName, col.DataType);
        foreach (DataColumn col in dt2.Columns)
            dtResult.Columns.Add(col.ColumnName, col.DataType);
               
        //fill data
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            dtResult.Rows.Add(dt1.Rows[i].ItemArray.Concat(dt2.Rows[i].ItemArray).ToArray());
        }
        return dtResult;
    }
