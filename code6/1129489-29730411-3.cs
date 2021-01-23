    public class SearchCriteria
    {
        public string PropertyName { get; set; }
        public string LikeValue { get; set; }
    }
    public static class MyExtension
    {
       public static IQueryOver<Employee, Employee> ConstructQueryConditions(
            this IQueryOver<Employee, Employee> query
            , SearchCriteria criteria)
        {
            if (criteria.PropertyName.IsNotEmpty())
            {
                query.Where(Restrictions.Like(criteria.PropertyName, criteria.LikeValue));
            }
            return query;
        }
