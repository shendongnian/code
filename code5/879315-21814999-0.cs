    string query = @"username =?, [password] = ?, contact =?
                    ref_no = ? WHERE id = ?";
    List<OleDbParameter> parameters = new List<OleDbParameter>();
    OleDbParameter p = new OleDbParameter("@p1", OleDbType.VarChar).Value = txtBoxUsername.Text;
    parameters.Add(p);
    p = new OleDbParameter("@p2", OleDbType.VarChar).Value = textBoxPassword.Text;
    parameters.Add(p);
    p = new OleDbParameter("@p3", OleDbType.VarChar).Value = ContactNo.Text;
    parameters.Add(p);
    p = new OleDbParameter("@p4", OleDbType.Integer).Value = Convert.ToInt32(textBoxReferenceno.Text);
    parameters.Add(p);
    p = new OleDbParameter("@p5", OleDbType.Integer).Value = Convert.ToInt32((textBoxId.Text);
    parameters.Add(p);
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
