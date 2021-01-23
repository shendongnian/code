    foreach (DataRow row in tb.Rows)
    {
        tblResult.ImportRow(row);
        DataRow newRow = tblResult.Rows[tblResult.Rows.Count - 1];
        newRow["CountT"] = sensorColumns.Count(c => row.Field<string>(c) == "T");
        newRow["CountF"] = sensorColumns.Count(c => row.Field<string>(c) == "F");
    }
