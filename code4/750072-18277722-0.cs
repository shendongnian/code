    public class test
    {
        object missing = Type.Missing;
        public test()
        {
            Excel.Application XL = new Excel.Application();
            oXL.Visible = false;
            Excel.Workbook WB = XL.Workbooks.Add(missing);
            Excel.Worksheet Sheet = WB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = "First sheet";
            oSheet.Cells[1, 1] = "Written on first sheet";
            Excel.Worksheet Sheet2 = WB.Sheets.Add(missing, missing, 1, missing) 
                        as Excel.Worksheet;
            Sheet2.Name = "Second sheet";
            Sheet2.Cells[1, 1] = "Written on second sheet";
            string fileName = @"C:\temp\SoSample.xlsx";
            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook,
                missing, missing, missing, missing,
                Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
            oWB.Close(missing, missing, missing);
            oXL.UserControl = true;
            oXL.Quit();
        }
    }
