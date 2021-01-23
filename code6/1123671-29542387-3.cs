    private List<DispatchInvoiceCTNDataModel> WorksheetToDataTableForInvoiceCTN(ExcelWorksheet excelWorksheet, int month, int year)
    {
        int totalRows = excelWorksheet.Dimension.End.Row;
        int totalCols = excelWorksheet.Dimension.End.Column;
        DataTable dt = new DataTable(excelWorksheet.Name);
        
        //Build the schema before we loop in parallel.
        for (int j = 1; j <= totalCols; j++)
        {
            var colName = excelWorksheet.Cells[1, j].Value.ToString().Replace(" ", String.Empty);
            if (!dt.Columns.Contains(colName))
                dt.Columns.Add(colName);
        }
        Parallel.For(2, totalRows + 1, (i) =>
        {
            DataRow dr = null;
            lock(lockObject) {
                dr = dt.Rows.Add();
            }
            for (int j = 1; j <= totalCols; j++)
            {
                dr[j - 1] = excelWorksheet.Cells[i, j].Value != null ? excelWorksheet.Cells[i, j].Value.ToString() : null;
            }
        });
        var excelDataModel = dt.ToList<DispatchInvoiceCTNDataModel>();
        // now we have mapped everything expect for the IDs
        excelDataModel = MapInvoiceCTNIDs(excelDataModel, month, year, excelWorksheet);
        return excelDataModel;
    }
