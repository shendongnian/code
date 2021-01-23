    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
    
            Public Form1()
            {
                InitializeComponent();
            }
    
            //~~> Open File
            private void button1_Click(object sender, EventArgs e)
            {
                xlexcel = new Excel.Application();
    
                xlexcel.Visible = true;
    
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open("C:\\MyFile.xlsx", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                xlWorkSheet.Cells[1, 1] = "FirstName";
                xlWorkSheet.Cells[1, 2] = "LastName";
                xlWorkSheet.Cells[1, 3] = "JobTitle";
                xlWorkSheet.Cells[1, 4] = "Address";
            }
    
            //~~> Add Data
            private void button2_Click(object sender, EventArgs e)
            {
                int _lastRow = xlWorkSheet.Range["A" + xlWorkSheet.Rows.Count].End[Excel.XlDirection.xlUp].Row + 1 ;
    
                xlWorkSheet.Cells[_lastRow, 1] = textBox1.Text;
                xlWorkSheet.Cells[_lastRow, 2] = textBox2.Text;
                xlWorkSheet.Cells[_lastRow, 3] = textBox3.Text;
                xlWorkSheet.Cells[_lastRow, 4] = textBox4.Text;
            }
    
            //~~> Once done close and quit Excel
            private void button3_Click(object sender, EventArgs e)
            {
                xlWorkBook.Close(true, misValue, misValue);
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
    
