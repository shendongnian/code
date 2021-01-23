    private void AddNewProfile() {
     try {
            using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.dbConnectionString)) {
            using(SqlCeCommand cmd = new SqlCeCommand()) {
             cmd.Connection = conn;
    
             cmd.CommandText = "INSERT INTO Profiles (ProfileName, ProfilePath, 
                             ProfileDescription) VALUES (@name,@path, @desc);";
             cmd.Parameters.AddWithValue("@name","New Profile");
	         cmd.Parameters.AddWithValue("@path","C:\\");
             cmd.Parameters.AddWithValue("@desc","A blank profile.");
    	     conn.Open();
             cmd.ExecuteNonQuery();             
            }
            }
        }
        catch(Exception ex) {
            MessageBox.Show(ex.Message, "Error");
        }
    }
