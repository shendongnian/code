    static void Main(string[] args)
    {
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(@"C:\Users\Martijn\Documents\Test.xlsx", ReadOnly: false, Editable:true);
            Worksheet worksheet = workbook.Worksheets.Item[1] as Worksheet;
            if (worksheet == null)
                return;
            Range row1 = worksheet.Rows.Cells[1, 1];
            Range row2 = worksheet.Rows.Cells[2, 1];
            row1.Value = "Test100";
            row2.Value = "Test200";
            excel.Application.ActiveWorkbook.Save();
            excel.Application.Quit();
            excel.Quit();
        }
