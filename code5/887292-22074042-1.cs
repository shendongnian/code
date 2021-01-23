    using Excel = Microsoft.Office.Interop.Excel;
    public static void LoadExcelFile()
    {
        Excel.Application EXCEL_FILE = new Excel.Application();
        EXCEL_FILE = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    }
