    using System;
    using System.Windows.Forms;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel; 
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open("C:\\Shapes.xlsx", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                // Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                foreach (Microsoft.Office.Interop.Excel.Shape Shp in xlWorkSheet.Shapes)
                {
                    // Disclaimer: I am a vb.net guy so if you feel the syntax of switch should be written 
                    // in some other way then feel free to edit it :) In VB.Net, I could write 
                    // Case 33 To 60 instead of writing so many cases.
                    switch ((int)Shp.AutoShapeType)
                    {
                        case 33: case 34: case 35: case 36: case 37: case 38: case 39: case 40:
                        case 41: case 42: case 43: case 44: case 45: case 46: case 47: case 48:
                        case 49: case 50: case 51: case 52: case 53: case 54: case 55: case 56:
                        case 57: case 58: case 59: case 60:
                                MessageBox.Show("Shape Found in Cell Range from " + 
                                                 Shp.TopLeftCell.Address + 
                                                 " to " + 
                                                 Shp.BottomRightCell.Address);
                            
                        break;
                    }
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
