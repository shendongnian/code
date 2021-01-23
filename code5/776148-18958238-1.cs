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
                Excel.Range Rng, aCell, bCell;
                String sMsg = "";
    
                object misValue = Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
    
                //~~> Open a File (Chnage filename as applicable)
                xlWorkBook = xlexcel.Workbooks.Open("C:\\MyFile.xlsx",
                             0, true, 5, "", "", true,
    
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                "\t", false, false, 0, true, 1, 0);
    
                //~~> Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                //~~> Delete relevant columns in reverse order
                //A,c,f,g,h,i,j,k,l,m,n,t,u,v,w,x,AA
    
                xlWorkSheet.get_Range("AA1", "AA1").EntireColumn.Delete();
                xlWorkSheet.get_Range("T1", "X1").EntireColumn.Delete();
                xlWorkSheet.get_Range("F1", "N1").EntireColumn.Delete();
                xlWorkSheet.get_Range("C1", "C1").EntireColumn.Delete();
                xlWorkSheet.get_Range("A1", "A1").EntireColumn.Delete();
    
                //~~> Insert the Category Column
                xlWorkSheet.get_Range("B1", "B1").EntireColumn.Insert(
                Excel.XlInsertShiftDirection.xlShiftToRight);
    
                //~~> get the last row and the last column of your data range
                //~~> This is much better than using usedrange  which might
                //'~~> include unnecessary ranges
                int lRow = xlWorkSheet.Cells.SpecialCells(
                           Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                int lCol = xlWorkSheet.Cells.SpecialCells(
                           Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Column;
    
                String Addr = xlWorkSheet.Cells[1, lCol].Address;
                //~~> This is to get the column name from column number
                String ColName = Addr.Split('$')[1];
    
                //~~> This is your data range. I am assuming that Row 1 has headers
                Rng = xlWorkSheet.get_Range("C2:" + ColName + lRow, misValue);
    
                //~~> Find the first occurance of "X"
                aCell = Rng.Find("X",misValue,Excel.XlFindLookIn.xlValues,
                        Excel.XlLookAt.xlWhole,misValue,
                        Excel.XlSearchDirection.xlNext,misValue,misValue,misValue);
    
                //~~> Find the next occurance of "X" using FindNext
                if(aCell != null)
                {
                    //~~> Get the column number and subtract 2 from it
                    int col = aCell.Column-2;
    
                    //~~> Choose the relevant keyword
                    if (col == 1)
                    {
                        sMsg = "Element";
                    }
                    else if (col == 2)
                    {
                        sMsg = "propername";
                    }
                    else if (col == 3)
                    {
                        sMsg = "physical";
                    }
                    else if (col == 4)
                    {
                        sMsg = "logical";
                    }
                    else if (col == 5)
                    {
                        sMsg = "extension";
                    }
    
                    //~~> Populate the Category Column
                    xlWorkSheet.Cells[aCell.Row, 2].Value = sMsg;
    
                    string sFirstFoundAddress = aCell.get_Address(true, true,
                    Excel.XlReferenceStyle.xlA1, misValue, misValue);
    
                    bCell = Rng.Cells.FindNext(aCell);
    
                    string sAddress = bCell.get_Address(true, true,
                    Excel.XlReferenceStyle.xlA1, misValue, misValue);
    
                    //~~> FindNext until the first found cell is found again
                    While (!sAddress.Equals(sFirstFoundAddress))
                    {
                        //~~> Get the column number and subtract 2 from it
                        col = bCell.Column-2;
    
                        //~~> Choose the relevant keyword
                        if (col == 1)
                        {
                            sMsg = "Element";
                        }
                        else if (col == 2)
                        {
                            sMsg = "propername";
                        }
                        else if (col == 3)
                        {
                            sMsg = "physical";
                        }
                        else if (col == 4)
                        {
                            sMsg = "logical";
                        }
                        else if (col == 5)
                        {
                            sMsg = "extension";
                        }
    
                        xlWorkSheet.Cells[bCell.Row, 2].Value = sMsg;
    
                        bCell = Rng.Cells.FindNext(bCell);
    
                        sAddress = bCell.get_Address(true, true,
                        Excel.XlReferenceStyle.xlA1, misValue, misValue);
                    }
                }
    
                //~~> Once done close and quit Excel
                xlWorkBook.Close(true, misValue, misValue);
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
