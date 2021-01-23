    using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\users\\alan\\desktop\\TestDatabase.mdb"))
        {
            OleDbCommand command = new OleDbCommand("SELECT MovieName FROM Movies", connection);
            connection.Open();
            OleDbDataReader dr = com.ExecuteReader();
    
            while (dr.Read())
            {
    	    var strValue = dr.GetString(0);
               //or  var strValue = reader["MovieName"].ToString();
            }
            reader.Close();
        }
