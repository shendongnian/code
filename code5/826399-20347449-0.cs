    DataSet ds_output = new DataSet();
    DataTable tblOutput = ds_input.Tables[0].Clone();
    ds_output.Tables.Add(tblOutput);
    foreach (DataRow dr in ds_input.Tables[0].Rows)
    {
        tblOutput.ImportRow(dr);
        // or:
        DataRow newRow = tblOutput.Rows.Add();
        newRow.ItemArray = dr.ItemArray;
    }
