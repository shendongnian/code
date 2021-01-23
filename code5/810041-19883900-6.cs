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
        {
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            adapter.InsertCommand = commandBuilder.GetInsertCommand()
            adapter.Update(data);
        }
    }
