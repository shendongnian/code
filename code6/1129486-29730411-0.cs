    using NHibernate.Criterion;
    
    namespace MyNamespace
    {
        public interface IBusinessObject
        {
            int ID { get; }
            string Name { get; }
        }
    
            public static QueryOver<T, U> AddSomeFilter<T, U>(QueryOver<T, U> queryOver)
                where T: IBusinessObject
                where U: IBusinessObject
            {
    
                queryOver
                    .Where(x => x.ID > 1)
                    .Where(x => x.Name == "Abc");
    
                return queryOver;
            }
        }
    }
