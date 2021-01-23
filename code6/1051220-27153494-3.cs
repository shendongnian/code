    public static class ProjectionExtensions
    {
        public static IProjection SplitPart<T>(
            Expression<Func<T, object>> expression,
            string delimiter, 
            int field)
        {
            return Projections.SqlFunction(
                "split_part",
                NHibernateUtil.String,
                Projections.Property<T>(expression),
                Projections.Constant(delimiter),
                Projections.Constant(field));
        }
    } 
