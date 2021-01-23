    namespace ExcelAddIn1OpenEventFromSharepoint
    {
        public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                this.Application.WorkbookOpen +=new Excel.AppEvents_WorkbookOpenEventHandler(Application_WorkbookOpen);
            }
    
            private void Application_WorkbookOpen(Microsoft.Office.Interop.Excel.Workbook Wb)
            {
                if (Globals.ThisAddIn.Application.ActiveWorkbook.Final)
                {
                    System.Windows.Forms.MessageBox.Show("This is a readonly workbook");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("This is read/write workbook");
                }
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
             //[VSTO Generated Code]
        }
    }
