      public static class Bootstrapper
      {
        public static int initialized = 0;
        public static void WarmUpEF()
        {            
            using (var context = new ReportingDbContext())
            {
                context.Database.Initialize(false);
            }
            initialized = 9999; // I'll explain this
        }
    }
