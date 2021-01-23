     try
            {
        
            }
          catch(SqlException sqlex)
            {
              if(sqlex.Number ==547)
                   {
                       //code
                   }
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
