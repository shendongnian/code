    public static class IQueryableExtensions {
    	public static IQueryable<T> ToPagedQuery(this IQueryable<T> query, int pageSize, int pageNumber) {
    		return query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
    	}
    }
