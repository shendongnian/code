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
                // here we can play with ID, and Name
                // because we know that U is of a type IBusinessObject
                queryOver
                    .Where(x => x.ID > 1)
                    .Where(x => x.Name == "Abc");
    
                return queryOver;
            }
        }
    }
