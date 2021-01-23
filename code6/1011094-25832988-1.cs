    internal static List<T> GetReader<T>(SQLiteCommand command, Func<SQLiteDataReader, T> readItem) {
      List<T> list = new List<T>();
      using (SQLiteDataReader reader = command.ExecuteReader()) {
        while (reader.Read()) {
          list.Add(readItem(reader));
        }
      }
      return list;
    }
