    public static void writeDataTableToServer(string ConnString, string selectStmt, DataTable dtToWrite)
        {
            using (OdbcConnection odbcConn = new OdbcConnection(ConnString))
            {
                odbcConn.Open();
                using (OdbcTransaction trans = odbcConn.BeginTransaction())
                {
                    using (OdbcDataAdapter daTmp = new OdbcDataAdapter(selectStmt, ConnString))
                    {
                        using (OdbcCommandBuilder cb = new OdbcCommandBuilder(daTmp))
                        {
                            
                            try
                            {
                                cb.ConflictOption = ConflictOption.OverwriteChanges;
                                daTmp.UpdateBatchSize = 5000;
                                daTmp.SelectCommand.Transaction = trans;
                                daTmp.SelectCommand.CommandTimeout = 120;
                                daTmp.InsertCommand = cb.GetInsertCommand();
                                daTmp.InsertCommand.Transaction = trans;
                                daTmp.InsertCommand.CommandTimeout = 120;
                                daTmp.UpdateCommand = cb.GetUpdateCommand();
                                daTmp.UpdateCommand.Transaction = trans;
                                daTmp.UpdateCommand.CommandTimeout = 120;
                                daTmp.DeleteCommand = cb.GetDeleteCommand();
                                daTmp.DeleteCommand.Transaction = trans;
                                daTmp.DeleteCommand.CommandTimeout = 120;
                                daTmp.Update(dtToWrite);
                                trans.Commit();
                            }
                            catch (OdbcException ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                odbcConn.Close();
            }
        }
