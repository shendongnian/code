       public List<string> GetColumns(string tableName)
        {
            List<string> colList = new List<string>();
            DataTable dataTable = new DataTable();
            string cmdString = String.Format("SELECT TOP 0 * FROM {0}", tableName);
            if (ConnectionManager != null)
            {
                try
                {
                    using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, ConnectionManager.ConnectionToSQL))
                    {
                        dataContent.Fill(dataTable);
                        foreach (DataColumn col in dataTable.Columns)
                        {
                           colList.Add(col.ColumnName);
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    InternalError = ex.Message;
                }
            }
            return colList;
        }
