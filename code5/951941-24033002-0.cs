        Sqlconnection con=new SqlConnection();
        con.ConectionString="myconnectionstring";
        try
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //Everything ok -> continue normally
        }
        catch(Exception ex)
        {
            MessageBox.Show("Database connection not available..."));//do something in case of error : exit application, log ex.Message, etc
        }
