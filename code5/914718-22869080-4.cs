    foreach(string line in lines) 
    {
        string[] values = line.split[';'];
        if(values.Length >= 3)
        {
            SqlCommand command = new SqlCommand(query, con);
            string query = "INSERT INTO demooo VALUES ('" + Values[0] + "','" + Values[1] + "','" + Values[2] + "')";      
            cmd.ExecuteNonQuery();                
        }
    }
        
