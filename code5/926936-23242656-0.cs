    Dictionary<int, string> Names = new Dictionary<int, string> ();
    using (SqlCommand command = new SqlCommand ("SELECT * FROM TestTable", con))
    using (SqlDataReader reader = command.ExecuteReader ()) {
       while (reader.Read ()) {
          Names.Add (reader["ID"], reader["NAME"]);
       }
    }
    
    if (!Names.ContainsValue ("ValueYouWantToInsert")) {
       //do stuff
    }
