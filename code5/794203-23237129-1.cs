          //this is all lib that i used|||||||||||||||
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using UsbLibrary;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Globalization;
            //cocy in a button||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            SqlConnection _connection = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand _command = new SqlCommand();
            DataTable _dataTable = new DataTable();
            _connection = new SqlConnection();
            _dataAdapter = new SqlDataAdapter();
            _command = new SqlCommand();
            _dataTable = new DataTable();
            //dbk is my database name that you can change it to your database name
            _connection.ConnectionString = "Data Source=.;Initial Catalog=dbk;Integrated Security=True";
            _connection.Open();
            SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
            saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
            saveFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialogCSV.FilterIndex = 1;
            saveFileDialogCSV.RestoreDirectory = true;
            
            string   path_csv="";
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                // Runs the export operation if the given filenam is valid.
                path_csv=   saveFileDialogCSV.FileName.ToString();
            }
                 DumpTableToFile(_connection, "tbl_trmc", path_csv);
            }
            //end of code in button|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        public void DumpTableToFile(SqlConnection connection, string tableName, string destinationFile)
        {
            using (var command = new SqlCommand("select * from " + tableName, connection))
            using (var reader = command.ExecuteReader())
            using (var outFile = System.IO.File.CreateText(destinationFile))
            {
                string[] columnNames = GetColumnNames(reader).ToArray();
                int numFields = columnNames.Length;
                outFile.WriteLine(string.Join(",", columnNames));
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] columnValues =
                            Enumerable.Range(0, numFields)
                                      .Select(i => reader.GetValue(i).ToString())
                                      .Select(field => string.Concat("\"", field.Replace("\"", "\"\""), "\""))
                                      .ToArray();
                        outFile.WriteLine(string.Join(",", columnValues));
                    }
                }
            }
        }
        private IEnumerable<string> GetColumnNames(IDataReader reader)
        {
            foreach (DataRow row in reader.GetSchemaTable().Rows)
            {
                yield return (string)row["ColumnName"];
            }
        }
