    var masterTable = new SomeTypedDataTable();
    Parallel.ForEach(fileArray,
                     () => new SomeTypedDataTable(), //Create a temp table per thread
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
                        lock (masterTable)
                        {
                            //Merge in the thread local table to the master table
                            masterTable.Merge(localTable); 
                        }
                    });
