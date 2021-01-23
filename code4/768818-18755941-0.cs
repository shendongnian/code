     Try this code,I hope this will work
    myConnection.Open();
        if (director.Operation == 'I')
            {
              query = "INSERT...";
        string query1="select  createdId  from table";
        
            }
        var cmd = new SqlCommand(query, myConnection);
        Sqlcommand cmd1=new SqlCommand(query1,myConnection);
            cmd.ExecuteNonQuery();
        int CreatedId=cmd1.ExecuteScalar();
        return  CreatedId;
            myConnection.Close();
         myConnection.Close();
