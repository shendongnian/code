    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            Public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Microsoft.Office.Interop.Excel.Range xlRange;
    
                object misValue = System.Reflection.Missing.Value;
    
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
    
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open("C:\\Book1.xlsx", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    
                // Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                xlRange = xlWorkSheet.UsedRange;
    
                for (int i = 1; i <= xlRange.Rows.Count; i++)
                {
                    MessageBox.Show(i.ToString());
                }
    
                //Once done close and quit Excel
                xlWorkBook.Close(false, misValue, misValue);
                xlexcel.Quit();
    
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
