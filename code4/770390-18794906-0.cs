    try
    {
        using(MySqlConnection myConn = new MySqlConnection(.....))
        using(MySqlCommand comm1 = new MySqlCommand(......))
        {
             myConn.Open();
             comm1.Parameters.AddWithValue("date_stamp", date);              
             .....
             comm1.ExecuteNonQuery(); 
        }
    }
    catch (MySqlException e)               
    {                    
        Console.WriteLine(e);                
    }
