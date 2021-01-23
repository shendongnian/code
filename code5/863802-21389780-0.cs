    public static class MyAppStorage
    {
        public static Task<bool> StoreInSqlAsync(string s)
        {
            return FakeStorageJobAsync(s);
        }
        public static Task<bool> StoreInOtherDatabaseAsync(string s)
        {
            return FakeStorageJobAsync(s);
        }
        private static async Task<bool> FakeStorageJobAsync(string s)
        {
            // This simulates waiting on a SQL database, or a web service, or any other storage task.
            await Task.Delay(300);
            return true;
        }
    }
