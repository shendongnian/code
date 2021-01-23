    using System;
    using System.IO;
    using UDC;
    using Excel = Microsoft.Office.Interop.Excel; //using Excel; in VS2003
 
    namespace ExcelToPDF
    {
    class Program
    {
        static void PrintExcelToPDF(string ExcelFilePath)
        {
            //Create a UDC object and get its interfaces
            IUDC objUDC = new APIWrapper();
            IUDCPrinter Printer = objUDC.get_Printers("Universal Document Converter");
            IProfile Profile = Printer.Profile;
 
            //Use Universal Document Converter API to change settings of converterd document
            Profile.PageSetup.ResolutionX = 600;
            Profile.PageSetup.ResolutionY = 600;
 
            Profile.FileFormat.ActualFormat = FormatID.FMT_PDF;
 
            Profile.FileFormat.PDF.ColorSpace = ColorSpaceID.CS_TRUECOLOR;
            Profile.FileFormat.PDF.Multipage = MultipageModeID.MM_MULTI;
 
            Profile.OutputLocation.Mode = LocationModeID.LM_PREDEFINED;
            Profile.OutputLocation.FolderPath = @"c:\UDC Output Files";
            Profile.OutputLocation.FileName = @"&[DocName(0)] -- &[Date(0)] -- &[Time(0)].&[ImageType]";
            Profile.OutputLocation.OverwriteExistingFile = false;
 
            Profile.PostProcessing.Mode = PostProcessingModeID.PP_OPEN_FOLDER;
 
            //Create a Excel's Application object
            Excel.Application ExcelApp = new Excel.ApplicationClass();
 
            Object ReadOnly = true;
            Object Missing = Type.Missing; //This will be passed when ever we don’t want to pass value
 
            //If you run an English version of Excel on a computer with the regional settings are configured for a non-English language, you must set the CultureInfo prior calling Excel methods.
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Open the document from a file
            Excel.Workbook Workbook = ExcelApp.Workbooks.Open(ExcelFilePath, Missing, ReadOnly, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing);
 
            //Change active worksheet settings and print it
            Excel.Worksheet Worksheet = (Excel.Worksheet)Workbook.ActiveSheet;
            Excel.PageSetup PageSetup = Worksheet.PageSetup;
 
            PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
 
            Object Preview = false;
            Worksheet.PrintOut(Missing, Missing, Missing, Preview, "Universal Document Converter", Missing, Missing, Missing);
 
            //Close the spreadsheet without saving changes
            Object SaveChanges = false;
            Workbook.Close(SaveChanges, Missing, Missing);
 
            //Close Microsoft Excel
            ExcelApp.Quit();
        }
 
        static void Main(string[] args)
        {
            string TestFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFile.xls");
            PrintExcelToPDF(TestFilePath);
        }
      }
    }
