    Parallel.ForEach(fileArray,
                     () => 
                        {
                            lock(table)
                            {   
                                //Create a temp table per thread that has the same schema as the main table
                                return table.Clone(); 
                            }
                        },
                     (file, loopState, localTable) =>
                        {
                            DataRow dataRow = localTable.NewRow();
                            var dr = GetDataRow(file, dataRow, parameters);
                            if (dr["MyVariable"].ToString() != "0")
                            {
                                try
                                {
                                    localTable.Rows.Add(dr);
                                }
                                catch (Exception exception)
                                {
                                    ConfigLogger.Instance.LogError(exception);
                                }
                            }
                            return localTable;
                        },
                    (localTable) =>
                    {
                        lock (table)
                        {
                            //Merge in the thread local table to the master table
                            table.Merge(localTable); 
                        }
                    });
