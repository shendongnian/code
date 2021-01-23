    DataTable dt = new DataTable();
    dt.Clear();
    dt.Columns.Add("TestCol");
    DataRow row = dt.NewRow();
    row["TestCol"] = "string that"+Environment.NewLine+"contains a linebreakc";
    dt.Rows.Add(row);
    using (var package = new ExcelPackage())
    {
        ExcelWorksheet ws = package.Workbook.Worksheets.Add("DataTable");
        ws.Cells["A1"].LoadFromDataTable(dt, true);
        package.SaveAs(new FileInfo(@"C:\Temp\test.xlsx"));
    }
            
