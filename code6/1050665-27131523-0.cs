    public class ExcelRow
    {
        public int ID { get; set; }
        public string Date1 { get; set; }
        public string Date2 { get; set; }
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        //source excel app
        var sourceExcelApp = new Excel.Application()
        {
            Visible = false,
            ScreenUpdating = false,
            DisplayAlerts = false
        };
        //get source workBook - assuming that path of source excel file is in C:\\
        Excel.Workbook sourceWorkbook = sourceExcelApp.Workbooks.Open(@"c:\\source.xls",
           Missing.Value, Missing.Value, Missing.Value,
           Missing.Value, Missing.Value, Missing.Value, Missing.Value,
           Missing.Value, Missing.Value, Missing.Value, Missing.Value,
           Missing.Value, Missing.Value, Missing.Value);
        //assuming that data is inside of first worksheet (WorkSheets[1])
        Excel._Worksheet sourceWorksheet = (Excel._Worksheet)sourceWorkbook.Worksheets[1];
        //get column ranges including header names
        Excel.Range ID = sourceWorksheet.Range["A1"];
        Excel.Range date1 = sourceWorksheet.Range["B1"];
        Excel.Range date2 = sourceWorksheet.Range["C1"];
        //get last row in table(from A1 to last cell in C column)
        int lastRowCount = sourceWorksheet.UsedRange.Rows.Count;
        var excelRow = new ExcelRow();
        List<ExcelRow> excelRowList = new List<ExcelRow>();
        //note that we start iteration from 1 in order not to read first cells values
        for (int i = 1; i < lastRowCount; i++)
        {
            excelRowList.Add(new ExcelRow
            {
                ID = int.Parse(ID.Offset[i, 0].Value2.ToString()),
                Date1 = date1.Offset[i, 0].Value2.ToString(),
                Date2 = date2.Offset[i, 0].Value2.ToString()
            });
        }
        //create new instance of target Excel app and
        var targetExcelApp = new Excel.Application();
        targetExcelApp.Visible = true;
        Excel.Workbook targetWorkbook = targetExcelApp.Workbooks.Add();
        Excel._Worksheet targetWorksheet = (Excel._Worksheet)targetExcelApp.ActiveSheet;
        //set columns headers titles
        targetWorksheet.Cells[1, "A"] = "ID";
        targetWorksheet.Cells[1, "B"] = "COLUMN_1";
        targetWorksheet.Cells[1, "C"] = "COLUMN_2";
        //formating target rows
        targetWorksheet.Range[String.Concat("B1:", "B", lastRowCount)].NumberFormat = "@";
        targetWorksheet.Range[String.Concat("C1:", "C", lastRowCount)].NumberFormat = "@";
        //fill targeted rows
        int counter = 1;
        foreach (var row in excelRowList)
        {
            counter++;
            targetWorksheet.Cells[counter, "A"] = row.ID;
            targetWorksheet.Cells[counter, "B"] = row.Date1;
            targetWorksheet.Cells[counter, "C"] = row.Date2;
        }
        //autofit columns width
        targetWorksheet.Columns.AutoFit();
        //save data to new excel app
        targetWorksheet.SaveAs("target", Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //release resources
        ReleaseObject(sourceWorksheet);
        ReleaseObject(sourceWorkbook);
        ReleaseObject(sourceExcelApp);
        ReleaseObject(targetWorksheet);
        ReleaseObject(targetWorkbook);
        ReleaseObject(targetExcelApp);
    }
