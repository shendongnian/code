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
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;
                sheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet).Sheets.Add();
                sheet.Cells[1, 1] = false;
                sheet.Cells[1, 2] = true;
                sheet.Columns.AutoFit(); //If the localized string doesn't fit in the default column width, the returned text will be ##########.
                localizedFalse = sheet.Cells[1, 1].Text;
                localizedTrue = sheet.Cells[1, 2].Text;
            }
            finally
            {
                if (sheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                }
                if (excel != null)
                {
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                }
            }
            Console.WriteLine("Excel localized true: {0} \r\nExcel localized false: {1}", localizedTrue, localizedFalse);
            Console.ReadLine();
        }
