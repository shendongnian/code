    public class MySqlConnector
    {
        private MySqlCommand _command;
    
        public void CreateView()
        {
            if(_command == null)
            {
                _command = new MySqlCommand();
            }
            
            const string sql = "Create View r2_Add_Edit_View as SELECT era.contact_id, era.n_family FROM era WHERE era.contact_id = @ContactID";
    
            _command.Parameters.AddWithValue("@ContactID", "10");
            _command.CommandText = sql;
            _command.Connection = con;
            _command.ExecuteNonQuery();
    
            _command.Close();
        }
    }
