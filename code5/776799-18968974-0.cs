    using System;
    using System.Windows.Forms;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    Namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
    
                object misValue = Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
    
                //~~> Open a File (Change filename as applicable)
                xlWorkBook = xlexcel.Workbooks.Open("C:\\SomeFile.xlsx",
                             0, true, 5, "", "", true,
    
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                "\t", false, false, 0, true, 1, 0);
    
                //~~> Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                Excel.Range cells = xlWorkSheet.Cells;
                Excel.Range topleftCell = cells[1][2];
    
                MessageBox.Show(topleftCell.Address);
    
                topleftCell = cells[1,2];
    
                MessageBox.Show(topleftCell.Address);
    
                //~~> Once done close and quit Excel
                xlWorkBook.Close(false, misValue, misValue);
                xlexcel.Quit();
    
                //~~> CleanUp
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
            }
    
            private void releaseObject(object obj)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                    MessageBox.Show("Unable to release the Object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }
