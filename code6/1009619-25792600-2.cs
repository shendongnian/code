    using SpreadsheetGear;
    using SpreadsheetGear.Printing;
    using SpreadsheetGear.Drawing.Printing;
    static void Main(string[] args)
    {
        // Create a workbook with some cell data
        IWorkbook workbook = Factory.GetWorkbook();
        IWorksheet worksheet = workbook.ActiveWorksheet;
        IRange cells = worksheet.Cells;
        cells["A1:D10"].Value = "=RAND()";
        // Create a WorkbookPrintDocument.  
        WorkbookPrintDocument printDocument = new WorkbookPrintDocument(worksheet, PrintWhat.Sheet);
        // Set the printer if necessary...let's go old school.
        printDocument.PrinterSettings.PrinterName = "Epson MX-80";
        // Print it
        printDocument.Print();
    }
