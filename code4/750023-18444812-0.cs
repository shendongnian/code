    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Data.SqlClient;
    namespace Payroll
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void fillToolStripButton_Click(object sender, EventArgs e)
            {
                try
                {
                    this.mIS_FTTIMECARTSQL1TableAdapter.Fill(this.fabTrolMRPDataSet.MIS_FTTIMECARTSQL1, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fromdateToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(todateToolStripTextBox.Text, typeof(System.DateTime))))));
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            private void Submit_Click(object sender, EventArgs e)
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                
                
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    int i = 0;
                    int j = 0;
                    for (i = 0; i <= mIS_FTTIMECARTSQL1DataGridView.RowCount - 1; i++)
                    {
                        for (j = 0; j <= mIS_FTTIMECARTSQL1DataGridView.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = mIS_FTTIMECARTSQL1DataGridView[j, i];
                            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                     
                        }
                    }
                    xlWorkBook.SaveAs("C:\\Time.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    MessageBox.Show("Excel file created , you can find the file c:\\Time.xls");
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
                    MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
       }
    }
    
