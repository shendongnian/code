    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace TestApplication
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select file",
                    Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
    
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    OleDbConnection conn = new OleDbConnection
                    {
                        ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName +
                                           ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\""
                    };
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
    
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable data = ds.Tables[0];
    
                    var message = string.Format("Row Count: {0}{1}Column Count: {2}", data.Rows.Count, Environment.NewLine, data.Rows[0].ItemArray.Count());
                    MessageBox.Show(message);
                }
            }
        }
    }
