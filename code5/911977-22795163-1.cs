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
                    for (int c = 0; c < oleReader.FieldCount; c++)
                    {
                        queryBuilder.Add(String.Format("Select '{0}' as ColumnName, max(len([{0}])) as MaxCharLength from [{1}]", oleReader.GetName(c), tableName));
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
