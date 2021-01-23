try
           {
               using (SqlConnection con = new SqlConnection(ConnectionSetting.SQLDBConnectionString()))
               {
                   con.Open();
                   using (SqlCommand com = new SqlCommand("spName", con))
                   {
                       com.CommandType = CommandType.StoredProcedure;
                       com.Parameters.Add(new SqlParameter("@dilivery_date", Convert.ToDateTime(recievedDateTxt.Text)));
                       using (SqlDataAdapter da = new SqlDataAdapter())
                       {
                           da.SelectCommand = com;
                           da.Fill(dtResult);
                       }
                   }
               }
               return dtResult;
           }
           catch (Exception)
           {
               throw;
           }
