    private readonly string _connString;
    public MySqlConnector(string connString)
    {
        _connString = connString;
    }
    private MySqlCommand _command;
    const string Sql = "Create View r2_Add_Edit_View as SELECT era.contact_id, era.n_family FROM era WHERE era.contact_id = @ContactID";
        
    public void CreateView(int contactId)
    {
        if(_command == null)
        {
            _command = new MySqlCommand();
            
            _command.CommandText = Sql;
            _command.Connection = _connString;
        }
        _command.Parameters.AddWithValue("@ContactID", contactId);
        _command.ExecuteNonQuery();
        _command.Close();
    }
}
