    public static IQueryable<T> MyFilter<T>(this IQueryable<T> queryable) where T : class ,IModel
        {
            var someIds = new int[] { 1, 2, 3, 4, 5 };
            var userId = 2;
            var result = queryable
                .Where(e => someIds.Contains(e.Id) || e.UserId == userId || e.CreatedDate != null);
            return result;
        }
