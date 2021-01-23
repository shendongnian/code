    public static class SearchExtensions
    {
        public static IQueryable<Student> Query(this SearchCriteria criteria, IQueryable<Student> studentQuery)
        {
            return studentQuery
                .Match(criteria.name, (student) => student.name == criteria.name)
                .Match(criteria.age, (student) => student.age == criteria.age)
                .Match(criteria.talent, (student) => student.talent == criteria.talent);
                // add expressions for other fields if needed.
        }
        private static IQueryable<Student> Match<T>(
            this IQueryable<Student> studentQuery,
            T criterionValue,
            Expression<Func<Student, bool>> whereClause) where T : class
        {
            // only use the expression if the criterion value is non-null.
            return criterionValue == null ? studentQuery : studentQuery.Where(whereClause);
        }
    }
