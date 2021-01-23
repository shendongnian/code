    DataTable wkbTable = new DataTable();
    wkbTable.Columns.Add("SpatialData", typeof(SqlString));
    for (int j = 0; j < arrOfWKT.Count; j++)
    {
        wkbTable.Rows.Add(arrOfWKT[j]);
    }
