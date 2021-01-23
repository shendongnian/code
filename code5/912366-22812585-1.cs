    public static class MyProjections
    {
        public static IProjection ConvertDate(params IProjection[] projections)
        {
            return Projections.SqlFunction("ConvertDate", 
                                NHibernateUtil.DateTime, projections);
        }
    }
