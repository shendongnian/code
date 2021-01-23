    using (SQLiteCommand command = new SQLiteCommand( ... )) {
      using (SQLiteDataReader reader = GetReader(command)) {
        // use the reader
      }
    }
