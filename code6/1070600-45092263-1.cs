    public static class HideSensitivePropertiesExtensions
    {
        public static async Task<TData> HideSensitivePropertiesForItem<TData>(this Task<TData> task)
            where TData : ModelBase
        {
            return (await task).HideSensitivePropertiesForItem();
        }
        public static TData HideSensitivePropertiesForItem<TData>(this TData item)
            where TData : ModelBase
        {
            item.Password = null;
            return item;
        }
        public static SingleResult<TData> HideSensitiveProperties<TData>(this SingleResult<TData> singleResult)
            where TData : ModelBase
        {
            return new SingleResult<TData>(singleResult.Queryable.HideSensitiveProperties());
        }
        public static IQueryable<TData> HideSensitiveProperties<TData>(this IQueryable<TData> query)
            where TData : ModelBase
        {
            return query.ToList().HideSensitiveProperties().AsQueryable();
        }
        public static IEnumerable<TData> HideSensitiveProperties<TData>(this IEnumerable<TData> query)
            where TData : ModelBase
        {
            foreach (var item in query)
                yield return item.HideSensitivePropertiesForItem();
        }
    }
