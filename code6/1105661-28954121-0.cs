    internal bool ValidateUser(string email, string password, bool rememberMe)
    {
    	bool valid = false;
    	using (_msqlCon = new MySqlConnection(_connectionString)) {
    		_msqlCon.Open();
    		_query = "SELECT Password, RememberMe FROM RegisteredUsers WHERE Email = @Email";
    
    		using (_command = new MySqlCommand(_query, _msqlCon)) {
    			_command.Parameters.AddWithValue("@Email", email);
    			MySqlDataReader reader = _command.ExecuteReader();
    
    			if (reader["Password"].Equals(password)) {
    				valid = true;
    			}
    		}
    	}
    	return valid;
    }
