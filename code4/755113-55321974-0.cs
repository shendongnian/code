    public static List<string> GetPrimaryKeyColumns(DbConnection connection, string tableName)
    {
            List<string> result = new List<string>();
            DbCommand command = connection.CreateCommand();
            string[] restrictions = new string[] { null, null, tableName };
            DataTable table = connection.GetSchema("IndexColumns", restrictions);
            if (string.IsNullOrEmpty(tableName))
                throw new Exception("Table name must be set.");
            foreach (DataRow row in table.Rows)
            {
                result.Add(row["column_name"].ToString());
            }
            return result;
    }
