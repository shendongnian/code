    Using (SqlConnection Sqlconn=new  
    SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
    {
        
      Sqlconn.open();
      Using (Sqlcommand cmd=new Sqlcommand())
      {
        cmd.CommandType=CommandType.StoredProcedure;
        cmd.CommandText="Data_Ins_Upd_Del";
        cmd.Parameters.AddWithValue("@UserID",UserID);
        cmd.ExceuteNonQuery();
        cmd.Parameters.Clear();
      } 
    }
