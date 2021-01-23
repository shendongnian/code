    public static class FilterPerson
    {
        static IQueryable<Person> FilterPerson(
           this IQueryable<Person> query,
           FilterString filter,
           Func<Person, string> selector,
            string searchText)
        {
            var enumerableQuery = query.AsEnumerable();
            switch (filter)
            {
                case FilterString.Contains:
                    enumerableQuery = enumerableQuery.Where(x => selector(x).ToLowerInvariant().Contains(searchText.ToLowerInvariant()));
                    break;
                case FilterString.DoesNotContain:
                    enumerableQuery = enumerableQuery.Where(x => !selector(x).ToLower().Contains(searchText.ToLower()));
                    break;
                case FilterString.StartsWith:
                    enumerableQuery = enumerableQuery.Where(x => selector(x).StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase));
                    break;
                case FilterString.EndsWith:
                    enumerableQuery = enumerableQuery.Where(x => selector(x).EndsWith(searchText, StringComparison.InvariantCultureIgnoreCase));
                    break;
                case FilterString.Equals:
                    enumerableQuery = enumerableQuery.Where(x => selector(x).Equals(searchText, StringComparison.InvariantCultureIgnoreCase));
                    break;
            }
    
            return enumerableQuery.AsQueryable();
        }
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    
    }
    
    public enum FilterString
    {
        StartsWith,
        Contains,
        DoesNotContain,
        EndsWith,
        Equals
    }
