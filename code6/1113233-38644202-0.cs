    public static class Extensions
    {
        public static void ToExcelFile(this DataTable dataTable, string filename, string worksheetName = "Sheet1")
        {
            using(var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable, worksheetName);
                workbook.SaveAs(filename);
            }
        }
    }
