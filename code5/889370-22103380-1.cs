    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace Excel_Sample
    {
        public partial class YourClass
        {
            Excel.Application appExcel;
            Excel.Workbook newWorkbook;
            Excel.Worksheet objsheet;
            string file = @"D:\file.xlsx";
    
            static void excel_init()
            {
                if (System.IO.File.Exists(file))
                {
                    //Start Excel and get Application object.
                    appExcel = new Excel.Application();
                    //Get a workbook.;
                    newWorkbook = (Excel.Workbook)(appExcel.Workbooks.Open(file));
    
                    int count = newWorkbook.Worksheets.Count;
                    if (count > 0)
                    {
                        //Get Your Worksheet
                        objsheet = (Excel.Worksheet)newWorkbook.ActiveSheet;
                    }
                }
                else
                {
                    MessageBox.Show("Unable to open file!");
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                    appExcel = null;
                    System.Windows.Forms.Application.Exit();
                }
            }
        }
    }
