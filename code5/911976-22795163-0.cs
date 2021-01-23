    private static DataTable GetMetaDataSummary(string tableName)
    {
        using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\bradley_handziuk\Documents\Database4.accdb;Persist Security Info=False;"))
        {
            var cmdText = String.Format("Select * from [{0}]", tableName);
            List<string> queryBuilder = new List<string>();
            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                using (OleDbDataReader oleReader = cmd.ExecuteReader())
                {
                    var cols = oleReader.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r["ColumnName"]).ToList();
                    foreach (var col in cols)
                    {
                        queryBuilder.Add(String.Format("Select '{0}' as ColumnName, max(len([{0}])) as MaxCharLength from [{1}]", col, tableName));
                    }
                }
            }
            var cmdText2 = String.Join(" Union All ", queryBuilder);
            using (OleDbCommand cmd = new OleDbCommand(cmdText2, conn))
            {
                using (OleDbDataReader oleReader = cmd.ExecuteReader())
                {
                    DataTable tableRecords = new DataTable();
                    tableRecords.Load(oleReader);
                    return tableRecords;
                }
            }
        }
    }
