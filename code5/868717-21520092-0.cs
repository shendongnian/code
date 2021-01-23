    public class Test : ITest
    {
        public int ExecuteDataAdapterDataTableWithParams<T>(IDbCommand podbCommand, ref T pdtDT) where T : DataTable
        {
            IDataAdapter ldaDataAdapter = default(IDataAdapter);
            IDbTransaction lodbTrans = default(IDbTransaction);
            int liFetchedRows = 0;
            lodbTrans = EstablishConnection();
            try
            {
                podbCommand.Connection = coConnection;
                podbCommand.Transaction = lodbTrans;
                ldaDataAdapter = GetDataAdapter(ref podbCommand);
                ldaDataAdapter.TableMappings.Add("Table", pdtDT.TableName);
                liFetchedRows = ldaDataAdapter.Fill(pdtDT.DataSet);
                liFetchedRows = pdtDT.Rows.Count;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref lodbTrans);
            }
            return liFetchedRows;
        }
    }
    
