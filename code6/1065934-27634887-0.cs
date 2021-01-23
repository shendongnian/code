	public bool BulkInsertDataTable(string tableName, DataTable dataTable, int Mode)
        {
            bool isSuccuss = false;
            try
            {
                if (Mode == 2)
                {
                    SqlConnectionObj.Open();
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionObj, SqlBulkCopyOptions.TableLock | 		    SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.WriteToServer(dataTable);
                    SqlConnectionObj.Close();
                    isSuccuss = true;
                }
            }
            catch (Exception ex)
            {
                isSuccuss = false;
                throw ex;
            }
            return isSuccuss;
        }
