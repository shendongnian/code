    SqlConnection con = new SqlConnection(connectionString);  
    
    SqlCommand cmd = new SqlCommand();  
    cmd.Connection = con;  
    cmd.CommandText = "SELECT datepart(year,incidentDate), ......";  
    
    con.Open();  
    
    cmd.ExecuteNonQuery();  
    
    SqlDataReader dr = cmd.ExecuteReader();
    
    while(dr.Read())
    {
       //Do something
    }
    
    con.Close();  
