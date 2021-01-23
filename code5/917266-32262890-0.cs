    public static void DynamicUpdateTable(string dbTableName, string primaryKey, DataTable table, bool deleteByFlag, params string[] ignoreColumns)
        {
            if (ignoreColumns == null)
                ignoreColumns = new string[0];
            if (table.Rows.Count == 0)
                return;
         
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand da = new SqlCommand())
            {
                da.Connection = conn;
                da.Connection.Open();
                
                // DELETES
                string deleteSQL;
                
                if (deleteByFlag)
                    deleteSQL = "UPDATE [" + dbTableName + "] SET Deleted = 1 WHERE [" + primaryKey + "] = @PrimaryKey";
                else
                    deleteSQL = "DELETE FROM [" + dbTableName + "] WHERE [" + primaryKey + "] = @PrimaryKey";
                da.CommandText = deleteSQL;
                foreach (DataRow row in table.Select(null, null, DataViewRowState.Deleted))
                {
                    da.Parameters.Clear();
                    da.Parameters.AddWithValue("@PrimaryKey", row[primaryKey, DataRowVersion.Original]);
                    da.ExecuteNonQuery();
                }
                // INSERTS  
                List<string> insertColumnNames = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    if (!ignoreColumns.Contains(column.ColumnName) &&
                        !column.AutoIncrement &&
                         column.GetType() != typeof(byte[]))
                        insertColumnNames.Add(column.ColumnName);
                }
                
                string insertSQL = 
                    "INSERT INTO [" + dbTableName + "] ([" + string.Join("], [", insertColumnNames.ToArray()) + "]) " + 
                    "VALUES (@" + string.Join(", @", insertColumnNames.ToArray()) + ")";
               
                da.CommandText = insertSQL;
                foreach (DataRow row in table.Select(null, null, DataViewRowState.Added))
                {
                    da.Parameters.Clear();
                    foreach (DataColumn column in table.Columns)
                    {
                        if (!ignoreColumns.Contains(column.ColumnName) &&
                            // ignore auto increment primary key
                            !column.AutoIncrement &&
                            // ignore all timestamps
                            column.GetType() != typeof(byte[]))
                            da.Parameters.AddWithValue("@" + column.ColumnName, row[column]);
                    }
                    
                    da.ExecuteNonQuery();
                }
                
                // DYNAMIC UPDATE         
                foreach (DataRow row in table.Select(null, null, DataViewRowState.ModifiedCurrent))
                {
                    da.Parameters.Clear();
                    // work out which columns have changed in the row
                    List<string> changedColumns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        if (!ignoreColumns.Contains(column.ColumnName) &&
                            !row[column, DataRowVersion.Original].Equals(row[column, DataRowVersion.Current]))
                        {
                            changedColumns.Add("[" + column.ColumnName + "] = @" + column.ColumnName);
                            da.Parameters.AddWithValue("@" + column.ColumnName, row[column, DataRowVersion.Current]);
                        }
                    }
                    // only update if there are actual changes
                    if (changedColumns.Count > 0)
                    {
                        string updateSQL = 
                            "UPDATE [" + dbTableName + "] SET " + string.Join(", ", changedColumns.ToArray()) +
                            " WHERE [" + primaryKey + "] = @" + primaryKey;
                        da.Parameters.AddWithValue("@" + primaryKey, row[primaryKey]);
                        da.CommandText = updateSQL;
                        da.ExecuteNonQuery();
                    }
                }
            }
            table.AcceptChanges();
        }
