      String strConnString =  ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
      SqlConnection con =  new SqlConnection(strConnString);
      SqlCommand cmd = new SqlCommand();
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandText = "GetPoint";
      cmd.Parameters.AddWithValue("@EmployeeID", Empid)   // ur input parameter//
      cmd.Connection = con;
       try
       {
      con.Open();
      GridView1.EmptyDataText = "No Records Found";
      GridView1.DataSource = cmd.ExecuteReader() ;
      GridView1.DataBind(); 
       }
      
