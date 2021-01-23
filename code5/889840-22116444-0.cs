    public static class EnumerableExtensions
    {
        private static readonly Type _enumerableType = typeof(Enumerable);
        public static IEnumerable CastAsType(this IEnumerable source, Type targetType)
        {
            var castMethod = _enumerableType.GetMethod("Cast").MakeGenericMethod(targetType);
            return (IEnumerable)castMethod.Invoke(null, new object[] { source });
        } 
        public static IList ToListOfType(this IEnumerable source, Type targetType)
        {
            var enumerable = CastAsType(source, targetType);
            var listMethod = _enumerableType.GetMethod("ToList").MakeGenericMethod(targetType);
            return (IList)listMethod.Invoke(null, new object[] { enumerable });
        } 
    }
