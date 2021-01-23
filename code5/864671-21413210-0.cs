    public static void InsertField(string table, string field, string values)
    {
        using (SQLiteConnection connection = new SQLiteConnection())
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                _table = table;
                _field = field;
                _values = values;
                String.Format("INSERT INTO {0} {1} VALUES{2}", _table, _field, _values);
                // and the rest of the code, incomplete in the example
            }
        }
    }
