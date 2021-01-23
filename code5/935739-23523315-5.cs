    public class MySqlConnector
    {
        private MySqlCommand _command;
        const string Sql = "Create View r2_Add_Edit_View as SELECT era.contact_id, era.n_family FROM era WHERE era.contact_id = @ContactID";
        
        public void CreateView(int contactId)
        {
            if(_command == null)
            {
                _command = new MySqlCommand();
                _command.Parameters.AddWithValue("@ContactID", contactId);
                _command.CommandText = Sql;
                _command.Connection = ClsVariables.StrDb;
            }
            _command.ExecuteNonQuery();
            _command.Close();
        }
    }
