        using System;
        using MSExcel = Microsoft.Office.Interop.Excel;
        using System.Runtime.InteropServices;
        static void Main(string[] args)
        {
            MSExcel.Application excel = null;
            MSExcel.Worksheet sheet = null;
            string localizedFalse;
            string localizedTrue;
            try
            {
                excel = new MSExcel.Application();
                excel.DisplayAlerts = false;
                sheet = (MSExcel.Worksheet)excel.Workbooks.Add(MSExcel.XlWBATemplate.xlWBATWorksheet).Sheets.Add();
                sheet.Cells[1, 1] = false;
                sheet.Cells[1, 2] = true;
                sheet.Columns.AutoFit(); //If the localized string doesn't fit in the default column width, the returned text will be ##########.
                localizedFalse = sheet.Cells[1, 1].Text;
                localizedTrue = sheet.Cells[1, 2].Text;
                
                Console.WriteLine("Excel localized true: {0} \r\nExcel localized false: {1}", localizedTrue, localizedFalse);
                Console.ReadLine();
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
                if (excel != null)
                {
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                }
            }
        }
