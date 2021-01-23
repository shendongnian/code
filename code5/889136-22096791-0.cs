    public static class BusinessValidator
    {
        public static TSource FirstOrDefault<TSource>(
        	this IEnumerable<TSource> source, string message)
        {
            TSource src = source.FirstOrDefault();
            if (src == null)
            {
                throw new Exception(message);
            }
            return src;
        }
    }
