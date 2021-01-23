     SQLiteCommand comID = new SQLiteCommand("Select max(id) from haltestellen", conSQLiteDb);
     conSQLiteDb.Open();
     SQLiteDataReader dr = comID.ExecuteReader(CommandBehavior.CloseConnection);
     if (dr.Read())
     {
        LblHaltestelleID1.Text = dr.GetValue(0).ToString();
     }
