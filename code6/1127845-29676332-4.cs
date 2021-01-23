    List<DataRow> rowsToRemove = new List<DataRow>();
    foreach (DataRow row in dt.Rows)
    {
        double RowDoubleValue;
        if (Double.TryParse(row["Salenumber"].ToString(), out RowDoubleValue) && RowDoubleValue >= 1.0 && RowDoubleValue <= 5999.0)
        {
            rowsToRemove.Add(row);
        }
    }
    foreach(DataRow row in rowsToRemove)
    {
        dt2.ImportRow(row); //Copy
        dt.Rows.Remove(row); //Remove
    }
