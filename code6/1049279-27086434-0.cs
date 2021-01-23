    catch (SqlException ex)
     {
        if(ex.Number == 40)
        {
          lblMessage.Text = "Cannot connect to database"  
        }
       else
       { 
        lblMessage.Text = ex.Message;
       }
     }
