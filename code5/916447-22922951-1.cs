    using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
    {
      using(SQLiteCommand mycommand = cnn.CreateCommand())
      {
         mycommand.CommandType = CommandType.Text;
         mycommand.CommandText = sql;
         using (SQLiteDataReader reader = mycommand.ExecuteReader())
         {
            dt.Load(reader);
         }
      }
      mycommand.Close();
    }
