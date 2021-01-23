    public static class MyExtensions
    {
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> source, Int32 count)
	    {
		    return source.OrderBy(s => Guid.NewGuid()).Take(count);
	    }
    }
