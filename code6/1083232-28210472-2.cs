     public static class BulkCopy
    {
        public static DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            if (IdentityColumnName != null)
            {
                if (IdentityColumnType == "int")
                    table.Columns.Add(IdentityColumnName, typeof(Int32));
                else if (IdentityColumnType == "string")
                    table.Columns.Add(IdentityColumnName, typeof(string));
            }
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            if (IdentityColumnName != null)
            {
                object[] values = new object[props.Count + 1];
                foreach (T item in data)
                {
                    for (int i = 1; i < values.Length; i++)
                    {
                        values[i] = props[i - 1].GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(values);
                }
            }
            else
            {
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    int i = 0;
                    for (i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(values);
                }
            }
            return table;
        }
        public static void BulkSqlInsert<T>(List<T> list, string tableName,string connectionString)
        {
            if (list == null)
                throw new Exception("List of " + typeof(T).ToString() + " is null!");
            BulkCopy.BulkSqlInsert(BulkCopy.ToDataTable<T>(list), tableName, connectionString);
        }
        public static void BulkSqlInsert(DataTable dt, string tableName, string connectionString)
        {
            if (dt.Rows.Count == 0)
                return;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlBulkCopy bulkCopy =
                    new SqlBulkCopy
                    (
                    connection,
                    SqlBulkCopyOptions.TableLock |
                    SqlBulkCopyOptions.FireTriggers |
                    SqlBulkCopyOptions.UseInternalTransaction,
                    null
                    );
               
                bulkCopy.DestinationTableName = tableName;
                connection.Open();
                
                bulkCopy.WriteToServer(dt);
                connection.Close();
            }
        }
        public static string IdentityColumnName { get; set; }
        public static string IdentityColumnType { get; set; }//string or int
        
    }
