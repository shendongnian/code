    SqlConnection conn = new SqlConnection(_connectionString);
    conn.Open();
    string s = "SELECT Company, Location " + 
               "FROM MainTable " +
               "WHERE LocationColumn = @location";
    SqlCommand cmd = new SqlCommand(s);
    cmd.Parameters.Add("@location", location.SelectedValue);
    SqlDataReader reader = cmd.ExecuteReader();
