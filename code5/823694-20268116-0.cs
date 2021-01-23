    public static SqlConnection[] GetConnections() 
    {
        SqlConnection con1 = new SqlConnection(str1);
        SqlConnection con2 = new SqlConnection(str2);
        con1.Open();
        con2.Open();
    
        return new SqlConnection[] { con1, con2 }; 
    }
