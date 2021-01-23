    public static SqlConnection GetConnection(string pass)
       {   
           string str = "Data Source=300.161.430.110 ;Initial Catalog =Pirulim;uid =sa;pwd ="+pass;        
           SqlConnection con = new SqlConnection(str);
           con.Open();         
           return con;
       }
