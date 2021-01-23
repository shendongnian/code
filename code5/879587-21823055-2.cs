    using(SqlConnection connection = new SqlConnection(connectionstring))
    using(SqlCommand command = new SqlCommand(sql,connection)) 
    {
        connection.Open();
        object ev = command.ExecuteScalar();
        bool flag; 
        if(ev!=null)
        {
           // return as null value, do Task 1 
        }else if(Boolean.TryParse(ev.ToString(), out flag) && flag)
        {
           // return as true value, do Task 2   
        }
        }else
        {
           // return as false value, do Task 3   
        }
    }
