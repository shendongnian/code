      string myConnectionString = ConfigurationManager.ConnectionStrings["ticketNotification.Properties.Settings.ticketsConnectionString"].ConnectionString;
      using(SqlConnection Conn = new SqlConnection(myConnectionString))
      {
         Conn.Open();
         //Define the SQL query need to be executed as a string
        //Create your command object
          
        //Create Dataset,Dataadapter if required
        //add parameters to your command object - if required
       //Execute your command
       //Display success message
     }
