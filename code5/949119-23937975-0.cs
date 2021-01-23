    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    namespace TestSandbox
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                var file1 = new DataTable();
                var file2 = new DataTable();
                InitializeComponent();
                using (var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\;Extended Properties=""text;HDR=Yes;FMT=Delimited"";"))
                {
                    conn.Open();
                    using (var adapter = new OleDbDataAdapter(@"select * from [us-500.csv]", conn))
                    {
                        adapter.Fill(file1);
                    }
                }
                using (var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\;Extended Properties=""text;HDR=Yes;FMT=Delimited"";"))
                {
                    conn.Open();
                    using (var adapter = new OleDbDataAdapter(@"select * from [us-500-2.csv]", conn))
                    {
                        adapter.Fill(file2);
                    }
                }
                var file1List = (from DataRow row in file1.Rows select row.ItemArray.Select(field => field.ToString()).ToArray() into fields select string.Join(",", fields)).ToList();
                var file2List = (from DataRow row in file2.Rows select row.ItemArray.Select(field => field.ToString()).ToArray() into fields select string.Join(",", fields)).ToList();
                file1List.AddRange(file2List.Except(file1List));
                File.WriteAllLines(@"C:\Results.csv", file1List.ToArray());
            }
        }
    }
