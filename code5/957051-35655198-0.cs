    public static class ExtendGenericType
    {
        public static IEnumerable<T> AsEnumerable<T>(this T entity)
        {
            yield return entity;
        }
    }
