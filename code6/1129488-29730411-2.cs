    public static class MyExtension
    {
        public static ICriteria AddLike(ICriteria criteria, string property, string likeValue)
        {
            if (property.IsNotEmpty())
            {
                criteria.Add(Restrictions.Like(property, likeValue));
            }
            return criteria;
        }
