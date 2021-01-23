    //Setup empty dataset for results setting its schema
                   dsResultSet.Tables.Add(ORM.GetDataSet("MyDataToProcess").Tables[0].Clone());
                    object key = new object();
                    
                    //Iterate in parallel your Dataset
                   Parallel.ForEach(ORM.GetDataSet("MyDataToProcess").Tables[0].AsEnumerable(), drow =>
                    {
                        if (((string)drow["DataRecordKey"]).Contains(SomeKey))
                        {
                            //some process with the record
                            //...
                            lock (key)
                            {
                                //Add the result to other disconnected DataSet
                                dsResultSet.Tables[0].BeginLoadData();
                                dsResultSet.Tables[0].Rows.Add(drow.ItemArray);
                                dsResultSet.Tables[0].EndLoadData();
                            }
                        }
                    });`
