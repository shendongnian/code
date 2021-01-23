    var dtCounts = new DataTable();
    using (var cmd = new MySqlCommand(query, DbConnect.Connection))
    {
         cmd.Parameters.AddWithValue(("@postcode"), DbConnect.Plot);
    
         using (var da = new MySqlDataAdapter(cmd))
         {
              da.Fill(dtCounts);
         }
    }
