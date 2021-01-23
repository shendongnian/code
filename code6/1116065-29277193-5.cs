    public static IQueryable AsQueryable(this IEnumerable source) {
                if (source == null)
                    throw Error.ArgumentNull("source");
                if (source is IQueryable)
                    return (IQueryable)source;
                Type enumType = TypeHelper.FindGenericType(typeof(IEnumerable<>), source.GetType());
                if (enumType == null)
                    throw Error.ArgumentNotIEnumerableGeneric("source");
                return EnumerableQuery.Create(enumType.GetGenericArguments()[0], source);
            }
