    try
        {
          using (SqlConnection conn = new SqlConnection("ConnectionString"))
             {
               conn.Open();
    
               SqlTransaction safetransaction = conn.BeginTransaction();
    
               foreach (var dado in NFSe)
                  {
    
                    SqlCommand cmd_NFSe = new 
                    SqlCommand("SqlCommand", conn, safetransaction);
                    cmd_NFSe.Connection = connection;
                    cmd_NFSe.Transaction = transaction;
    
                    var newID = cmd_NFSe.ExecuteScalar();
    
                    foreach (var serv in Servico)
                       {
    
                         string ID = newID.Tostring(); 
    
                         SqlCommand cmd_NFSeServ = new 
                         SqlCommand("SqlCommand", conn, safetransaction);
    
    
                         cmd_NFSeServ.ExecuteNonQuery();
                         cmd_NFSe.Commit();
                       }                                
    
                   }
              }
         }
    
     catch (SqlException ex)
         {
    
            cmd_NFSe.Rollback();
            MessageBox.Show(ex.ToString());
         }
