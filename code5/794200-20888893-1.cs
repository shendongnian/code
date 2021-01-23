    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    public class TableDumper
    {
        public void DumpTableToFile(SqlConnection connection, string tableName, string destinationFile)
        {
            using (var command = new SqlCommand("select * from " + tableName, connection))
            using (var reader = command.ExecuteReader())
            using (var outFile = File.CreateText(destinationFile))
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
    }
