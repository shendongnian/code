    using(SqlConnection connection = new SqlConnection(connectionstring))
    using(SqlCommand command = new SqlCommand(sql,connection)) 
    {
        connection.Open();
        object ev = command.ExecuteScalar();
        bool flag; 
        if(ev!=null && Boolean.TryParse(ev.ToString(), out flag) && flag)
        {
        
           // return as true 
        }
    }
