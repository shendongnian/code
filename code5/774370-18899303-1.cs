    string query = string.Empty;
    switch(.....)
    {
        ....
    }
    if(query.Length > 0)
    {
        cs.Open();
        SqlCommand cmd = new SqlCommand(query, cs);   <<--Error Message 
        SqlDataReader polygon = cmd.ExecuteReader();    
    }
