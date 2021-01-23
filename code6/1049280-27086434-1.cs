    catch (SqlException ex)
     {
        if(ex.Number == 40) // 40 is specific key for network issue
        {
          lblMessage.Text = "Cannot connect to database"  
        }
       else
       { 
        lblMessage.Text = ex.Message;
       }
     }
