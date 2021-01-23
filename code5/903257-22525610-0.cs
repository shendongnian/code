    public string opt()
    {
        string strng= "";
        string outval= "";
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =      ConfigurationManager.ConnectionStrings["nmrbg"].ConnectionString;
        conn.Open();
        SqlCommand cmd = new SqlCommand("nmp_sp_sy", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader rdr = cmd.ExecuteReader();    
        // if (rdr.HasRows)
        // {
       //     while (rdr.Read())
       //     {
       //        int nm= rdr.GetInt32(0);
       //        strng= Convert.ToString(nm);
       //        outval= strng;
       //     }
        // }
           while (rdr.Read())
           {
               if(rdr["ColumnName"] != DBNull.Value)
               {
                   int nm= rdr.GetInt32(0);
                   strng= Convert.ToString(nm);
                   outval= strng;
               }
                else
               {
                      outval= "0000";
               }
           }
        if (!rdr.HasRows)
        {
            outval= "0000";
        }
           rdr.Close();
           rdr.Dispose();
           conn.Close();
           conn.Dispose();
           return outval;
      }
