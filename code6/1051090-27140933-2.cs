    public int CheckIP()
    {
     string conn = "";
     conn = ConfigurationManager.ConnectionStrings["Connection"].ToString();
     SqlConnection sqlconn = new SqlConnection(conn);
     try
     {
         sqlconn.Open();
         DataSet ds = new DataSet();
         SqlCommand objcmd = new SqlCommand("sp_CheckIP", sqlconn);
         objcmd.CommandType = CommandType.StoredProcedure;
         SqlParameter IPAddress = objcmd.Parameters.Add("@IpAddress", SqlDbType.VarChar);
         IPAddress.Value = 0;
         
               
         SqlParameter returnParameter = new SqlParameter("@AllowedLogInAttempts", SqlDbType.Int);
         returnParameter.Direction = ParameterDirection.Output;
         objcmd.Parameters.Add(returnParameter);
          objcmd.ExecuteNonQuery();
         int id = (int) returnParameter.Value;    
         //Now here write your logic to assign value hidden field
     }
     catch (Exception ex)
     {
         Response.Write(ex.Message.ToString());
     }
     finally
     {
         sqlconn.Close();
     }
    }
