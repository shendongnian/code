    private string _getDataQuery = "select PLODINA, CENAZAQ, MJ from PLODINY";
    
    public void GetData(DataTable data)
    {
        //You do not need to call open here as SqlDataAdapter does it for you internally.
        using(var spojeni = new SqlConnection(GetConnectionString())
        using(var adapter = new SqlDataAdapter(_getDataQuery, spojeni)
        {
            data.Clear();
            adapter.Fill(data);
        }
    }
    
    public void UpdateData(DataTable data)
    {
        using(var spojeni = new SqlConnection(GetConnectionString())
        using(var adapter = new SqlDataAdapter(_getDataQuery, spojeni)
        using(var commandBuilder = new SqlCommandBuilder(adapter)
        {
            //This may or may not be nessesary for spojeni.BeginTransaction()
            spojeni.Open();
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
    }
