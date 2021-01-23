    public static class SomeRepository
    {
        public static IDbConnection Db = HostContext.TryResolve<IDbConnectionFactory>().OpenDbConnection();
        public static List<SomeEntity> DoSomething()
        {
            return Db.Select<SomeEntity>();
        }
    }
