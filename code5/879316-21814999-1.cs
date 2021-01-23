    string query = @"username =?, [password] = ?, contact =?
                    ref_no = ? WHERE id = ?";
    List<OleDbParameter> parameters = new List<OleDbParameter>();
    parameters.Add(new OleDbParameter()
          {ParameterName = "@p1, OleDbType = OleDbType.VarChar, 
           Value = txtBoxUsername.Text});
    parameters.Add(new OleDbParameter()
          {ParameterName = "@p2, OleDbType = OleDbType.VarChar, 
           Value = textBoxPassword.Text});
    parameters.Add(new OleDbParameter()
          {ParameterName = "@p3, OleDbType = OleDbType.VarChar, 
           Value = ContactNo.Text});
    parameters.Add(new OleDbParameter()
          {ParameterName = "@p4, OleDbType = OleDbType.Integer, 
           Value = Convert.ToInt32(textBoxReferenceno.Text)});
    parameters.Add(new OleDbParameter()
          {ParameterName = "@p5, OleDbType = OleDbType.Integer, 
           Value = Convert.ToInt32(textBoxId.Text)});
    new controllerclass().updateDatabase("[User]", query, parameters); 
    ....
    public bool updateDatabase(string type, string query, List<OleDbParameter>parameters) 
    { 
        try
        {
            OleDbCommand cmd = new OleDbCommand(); //open connection
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [" + type + "] SET " + query;
            cmd.Connection = conn;
            cmd.Parameters.AddRange(parameters.ToArray());
            cmd.ExecuteNonQuery(); //execute command
            closeConnection();
            return true;
        }
        ....
    }  
