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
    
            private void Submit_Click(object sender, EventArgs e);
            {
                DataTableToExcel();
            }
    
            public void DataTableToExcel()
            {
    
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                try
                {
    
                    // creating new WorkBook within Excel application
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    // see the excel sheet behind the program
                    app.Visible = true;
                    // get the reference of first sheet. By default its name is Sheet1.
                    // store its reference to worksheet
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    // changing the name of active sheet
                    worksheet.Name = "Employees";
                    // storing header part in Excel
                    for (int i = 1; i < mIS_FTTIMECARTSQL1DataGridView.Columns.Count + 1; i++)
                    {
                            worksheet.Cells[1, i] = mIS_FTTIMECARTSQL1DataGridView.Columns[i - 1].HeaderText;
                    }
    
                    // storing Each row and column value to excel sheet
                    for (int i = 0; i <= mIS_FTTIMECARTSQL1DataGridView.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < mIS_FTTIMECARTSQL1DataGridView.Columns.Count; j++)
                        {
                            string values = string.Empty;
                            values = mIS_FTTIMECARTSQL1DataGridView.Rows[i].Cells[j].Value.ToString();
                            worksheet.Cells[i + 2, j + 1] = values;
                        }
    
                    }
                }
                finally
                {
                    //Release the resources
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    app = null;
    
        
                }
    
          }
    }
