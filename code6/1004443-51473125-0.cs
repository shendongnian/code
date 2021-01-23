    public static class CSOMExtensions
    {
        public static Task ExecuteQueryAsync(this ClientContext clientContext)
        {
            return Task.Factory.StartNew(() =>
            {
                clientContext.ExecuteQuery();
            });
        }
    }
