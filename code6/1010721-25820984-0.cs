    using (SqlConnection con = new SqlConnection(--your-connection-string--))
    using (SqlCommand cmd = new SqlCommand(con))
    {
        string query = "SELECT distinct ha FROM app WHERE 1+1=2";
        if (comboBox1.Text != "")
        {
            // add an expression with a parameter
            query += " AND firma = @value1 ";
            // add parameter and value to the SqlCommand
            cmd.Parameters.Add("@value1", SqlDbType.VarChar, 100).Value = comboBox1.Text; 
        }
        .... and so on for all the various parameters you want to add
        cmd.CommandText = query;
        con.Open();
       
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
             while(reader.Read())
             {
                 // do something with reader -read values 
             }
             reader.Close();
        }
        con.Close();
    }
