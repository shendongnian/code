    namespace System.Data.Entity
    {
        public static class EntityFrameworkExtensions
        {
            public static IEnumerable<object> AsEnumerable(this DbSet set)
            {
                foreach (var entity in set)
                {
                    yield return entity;
                }
            }
        }
    }
