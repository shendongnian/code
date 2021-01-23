    using System;
    using Microsoft.Office.Interop.Excel;
    namespace officeInterop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
                Workbook wkb = app.Workbooks.Open("d:\\x.xlsx");
                wkb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, "d:\\x.pdf");
            }
        }
    }
