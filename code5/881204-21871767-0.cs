    OracleConnection con = OracleDatabase.connection();
    
    public static OracleConnection connection()
    {
     oradb =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
     string str = "Data Source="+db+";User ID="+userid+";Password="+password+";";
     oradb = String.Concat(oradb, str);        
     con = new OracleConnection(oradb);
     con.Open();
     return con;
    }
