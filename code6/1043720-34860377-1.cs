     public static class CustomQueryImplentations
     {
            public static IQueryable<Person> QueryImplementation(this IQueryable<Person> source)
            {
                return source
                    .Include(r => r.Addresses)
                    .OrderByDescending(c => c.Name);
            }
      }
