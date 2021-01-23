    class MyDatabase
    {
     SqlConnection cnn;
     SqlDataAdapter adp;
     DataSet ds;
     DataTable dt;
    
     public MyDatabase()
     {
      cnn = new SqlConnection();
      cnn.ConnectionString =     ConfigurationManager.ConnectionStrings["Courier_Management_System"].ToString();
      adp = new SqlDataAdapter();
      ds = new DataSet();
      dt = new DataTable();
     }
    }
