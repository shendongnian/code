    public static class Program
        {
            public class Person
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
            
            public static IQueryable<T> WherePropertyEquals<T, TProperty>(
                this IQueryable<T> src, Expression<Func<T, TProperty>> property, TProperty value)
            {
                var result = src.Where(e => property.Invoke(e).Equals(value));
                return result;
            }
            
            public static IQueryable<T> WhereGreater<T, TProperty>(
                this IQueryable<T> src, Expression<Func<T, TProperty>> property, TProperty value)
                where TProperty : IComparable<TProperty>
            {
                var result = src.Where(e => property.Invoke(e).CompareTo(value)>0);
                return result;
            }
    
            public static void Main()
            {
                var persons = new List<Person>()
                    {
                        new Person
                            {
                                FirstName = "Jhon",
                                LastName = "Smith"
                            },
                            new Person
                                {
                                    FirstName = "Chuck",
                                    LastName = "Norris"
                                },
                            new Person
                                {
                                    FirstName = "Ben",
                                    LastName = "Jenkinson"
                                     
                                }
                    }
                    .AsQueryable()
                    .AsExpandable();
    
                var chuck = persons.WherePropertyEquals(p => p.FirstName, "Chuck").First();
                var ben = persons.WhereGreater(p => p.LastName.Length, 6).First();
            }
            
        }
