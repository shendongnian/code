    Sqlconnection con=new SqlConnection();
    con.ConectionString="myconnectionstring";
    try
    {
      if(con.State==ConnectionState.Open)
       {
        con.Close();
       }
       con.Open();
        //Success message
    }
    catch(Exception)
    {
      //Failure Message
    }
