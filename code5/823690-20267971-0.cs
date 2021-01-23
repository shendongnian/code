    public static SqlConnection GetConnection()
    {
    
        string str = "Data Source=300.161.430.110 ;Initial Catalog =Pirulim;uid =sa;pwd = per#3";
    
    
        SqlConnection con = new SqlConnection(str);
        con.Open();
    
        return con;
    }
    
    public static SqlConnection GetConnection2()
    {
    
        string str2 = "Data Source=300.161.430.112 ;Initial Catalog =Pirulim;uid =sa;pwd = per#4";
    
    
        SqlConnection con = new SqlConnection(str2);
        con.Open();
    
    
        return con;
    }
