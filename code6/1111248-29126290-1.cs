    private static readonly MethodInfo CastMethodBase =
        ((Func<IEnumerable, IEnumerable<object>>)Enumerable.Cast<object>)
            .Method
            .GetGenericMethodDefinition();
    private static class CastMethodCache<T>
    {
        internal static Func<IEnumerable, IEnumerable<T>> CastMethod =
             (Func<IEnumerable, IEnumerable<T>>)CastMethodBase
                .MakeGenericMethod(typeof(T))
                .CreateDelegate(typeof(Func<IEnumerable, IEnumerable<T>>));
    }
    public static IEnumerable<T> CastWrap<T>(IEnumerable value)
    {
        return CastMethodCache<T>.CastMethod.Invoke(value);
    }
