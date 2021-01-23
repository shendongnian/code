        public override bool FileToDatabase(string filePath)
        {
            SqlConnection sqlConnection = new SqlConnection(“Connerction string”);
            
            try
            {
                StreamReader readFile = new StreamReader(filePath);
                
                string[] sArr = ("LineNumber|" + readVoteFile.ReadLine()).Split('|');
                int columnCount = 0;
                foreach (string s in sArr)
                {
                    columnCount++;                    
                }                
                string line = null;
                long counter = 0;
                bool hasMoreRows = true;
                DataTable FileDataTable = null;
                while (hasMoreRows)
                {
                    
                    line = readFile.ReadLine();
                    if (line == null)
                    {
                        hasMoreRows = false;
                    }
                    else
                    {
                        if (hasMoreRows && FileDataTable == null)
                        {
                            FileDataTable = new DataTable();
                            for (int i = 0; i < columnCount; i++)
                            {
                                FileDataTable.Columns.Add(new DataColumn());
                            }
                        }
                        DataRow row = FileDataTable.NewRow();
                        row.ItemArray = (counter + "|" + line).Split('|');
                        FileDataTable.Rows.Add(row);
                    }
                    if (counter != 0 && counter % base.FileProcessBatchSize == 0 && hasMoreRows || !hasMoreRows && FileDataTable != null && FileDataTable.Rows.Count > 0)
                    {
                        sqlConnection.Open();
                        SqlBulkCopy bc = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.TableLock, null);
                        bc.BatchSize = base.DBInsertBatchSize;
                        bc.BulkCopyTimeout = 1200;
                        bc.DestinationTableName = base.BulkCopyTable;
                        bc.WriteToServer(FileDataTable);
                        bc.Close();
                        sqlConnection.Close();
                        FileDataTable = null;
                    }
                    counter++;
                }
                readFile.Close();
                readFile.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                try { sqlConnection.Close(); }
                catch { }
                throw (ex);
            }
        }
