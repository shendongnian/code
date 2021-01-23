    using(MySqlConnection connection = new MySqlConnection(MyConString))
    {
         connection.Open();
         DataTable dt = new DataTable();
         using(MySqlDataAdapter da = new MySqlDataAdapter("Select Client_ID, ClientName, " + 
               "ClientAddress, ClientContactNo,ClientContactPerson " + 
               "from client_profile where ClientName like @cname",connection))
         {
             da.SelectCommand.Parameters.AddWithValue("@cname", "%" + txtCname.Text +"%");
             da.Fill(dt);
         }
     }
