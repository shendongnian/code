        private Microsoft.Office.Interop.Excel.Application appExcel;
        private Workbook newWorkbook = null;
        private _Worksheet objsheet = null;
        public void excel_init(String path)
        {
            appExcel = new Microsoft.Office.Interop.Excel.Application();
            if (System.IO.File.Exists(path))
            {
                // then go and load this into excel
                newWorkbook = appExcel.Workbooks.Open(path, true, true);
                objsheet = (_Worksheet)appExcel.ActiveWorkbook.ActiveSheet;
            }
            else
            {
                Console.WriteLine("Unable to open workbook");
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                appExcel = null;
            }
        }
