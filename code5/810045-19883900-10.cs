    private string _getDataQuery = "select PLODINA, CENAZAQ, MJ from PLODINY";
    
    public void GetData(SqlConnection spojeni, DataTable data)
    {
        using(var adapter = new SqlDataAdapter(_getDataQuery, spojeni)
        {
            data.Clear();
            adapter.Fill(data);
        }
    }
    
    public void UpdateData(SqlConnection spojeni, DataTable data)
    {
        using(var adapter = new SqlDataAdapter(_getDataQuery, spojeni)
        using(var commandBuilder = new SqlCommandBuilder(adapter)
        using(var sqlTrans = spojeni.BeginTransaction())
        {
            adapter.SelectCommand.Transaction = sqlTrans;
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.UpdateCommand.Transaction = sqlTrans;
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            adapter.DeleteCommand.Transaction = sqlTrans;
            adapter.InsertCommand = commandBuilder.GetInsertCommand()
            adapter.InsertCommand.Transaction = sqlTrans;
            
            try
            {
                adapter.Update(data);
                sqlTrans.Commit();
            }
            catch
            {
                sqlTrans.Rollback();
                throw;
            }
        }
    }
