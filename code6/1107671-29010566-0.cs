    using (MySqlConnection conn = new MySqlConnection("Your Connection String"))
    {
     string myQuery = "SELECT IMAGE FROM SOMETABLE";
        using(MySqlCommand cmd = new MySqlCommand(myQuery, conn))
        {
           conn.Open();
           using(var reader = new cmd.ExecuteReader())
           {
             someVariable = (byte[])reader["IMAGE"];
           }
        }
    }
