    namespace WindowsFormsApplication1
    {
        using System;
        using System.IO;
        using System.Reflection;
        using System.Runtime.InteropServices;
        using System.Windows.Forms;
    
        using Microsoft.Office.Interop.Excel;
    
        using Application = Microsoft.Office.Interop.Excel.Application;
    
        public partial class Form1 : Form
        {
            private Application xlExcel;
    
            private Workbook xlWorkBook;
    
            public Form1()
            {
                this.InitializeComponent();
            }
    
            private void btnExport_Click(object sender, EventArgs e)
            {
                try
                {
                    this.QuitExcel();
                    this.xlExcel = new Application { Visible = false };
                    this.xlWorkBook = this.xlExcel.Workbooks.Add(Missing.Value);
    
                    // Copy contents of grid into clipboard, open new instance of excel, a new workbook and sheet,
                    // paste clipboard contents into new sheet.
                    this.CopyGrid();
    
                    var xlWorkSheet = (Worksheet)this.xlWorkBook.Worksheets.Item[1];
    
                    try
                    {
                        var cr = (Range)xlWorkSheet.Cells[1, 1];
    
                        try
                        {
                            cr.Select();
                            xlWorkSheet.PasteSpecial(cr, NoHTMLFormatting: true);
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(cr);
                        }
    
                        this.xlWorkBook.SaveAs(Path.Combine(Path.GetTempPath(), "ItemUpdate.xls"), XlFileFormat.xlExcel5);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(xlWorkSheet);
                    }
    
                    MessageBox.Show("File Save Successful", "Information", MessageBoxButtons.OK);
    
                    // If box is checked, show the exported file. Otherwise quit Excel.
                    if (this.checkBox1.Checked)
                    {
                        this.xlExcel.Visible = true;
                    }
                    else
                    {
                        this.QuitExcel();
                    }
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
    
                // Set the Selection Mode back to Cell Select to avoid conflict with sorting mode.
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                this.QuitExcel();
            }
    
            private void QuitExcel()
            {
                if (this.xlWorkBook != null)
                {
                    try
                    {
                        this.xlWorkBook.Close();
                        Marshal.ReleaseComObject(this.xlWorkBook);
                    }
                    catch (COMException)
                    {
                    }
    
                    this.xlWorkBook = null;
                }
    
                if (this.xlExcel != null)
                {
                    try
                    {
                        this.xlExcel.Quit();
                        Marshal.ReleaseComObject(this.xlExcel);
                    }
                    catch (COMException)
                    {
                    }
    
                    this.xlExcel = null;
                }
            }
    
            private void CopyGrid()
            {
                // I'm making this up...
                this.dataGridView1.SelectAll();
    
                var data = this.dataGridView1.GetClipboardContent();
    
                if (data != null)
                {
                    Clipboard.SetDataObject(data, true);
                }
            }
        }
    }
