    public static class Extensions
    {
        public static IQueryable<string> GetCountries(this IQueryable<Customer> q) 
        {
            return q.GroupBy(c => c.Country).Select(x => LocalMethod(x.Key)); 
        }
        private static string LocalMethod(string country)
        {
            return country.ToUpper();
        }
    }
