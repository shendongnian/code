    public static class MySqlCommandExtension
    {
        public static Task<MySqlDataReader> MyExecuteReaderAsync(this MySqlCommand source, CommandBehavior behavior = CommandBehavior.Default)
        {
            return Task<MySqlDataReader>.Factory.FromAsync(source.BeginExecuteReader(behavior), source.EndExecuteReader);
        }
    }
