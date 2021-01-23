    using NHibernate.Criterion;
    
    namespace MyNamespace
    {
        public static class MyExtension
        {
            public static QueryOver<T, U> AddPaging<T, U>(QueryOver<T, U> queryOver)
            {
                queryOver
                    .Skip(10)
                    .Take(10);
    
                return queryOver;
            }
        }
    }
