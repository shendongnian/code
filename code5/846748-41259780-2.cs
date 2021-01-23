    public static class NLogDatabaseTarget
    {
        public static void GenerateInsertQueries()
        {
            NLog.LogManager.Configuration.GenerateDatabaseTargetInsertQueries();
        }
    }
