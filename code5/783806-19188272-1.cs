    public class CustomSumFunction : EnumerableSelectorAggregateFunction
    {
        protected override string AggregateMethodName
        {
            get { return "Sum"; }
        }
        protected override Type ExtensionMethodsType
        {
            get
            {
                return typeof(CustomAggregateFunctions);
            }
        }
    }
    public static class CustomAggregateFunctions
    {
        public static TValue Sum<T, TValue>(IEnumerable<T> source, Func<T, TValue> selector)
        {
            return source.Select(selector).Aggregate((t1, t2) => 
                {
                    Expression expr = Expression.Add(Expression.Constant(t1, t1.GetType()), Expression.Constant(t2, t2.GetType()));
                    Expression conversion = Expression.Convert(expr, typeof(TValue));
                    return Expression.Lambda<Func<TValue>>(conversion).Compile()();                    
                });
        }
        public static decimal? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return source.Sum(selector);
        }
        public static decimal Sum<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return source.Sum(selector);
        }
        public static double? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return source.Sum(selector);
        }
        public static double Sum<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return source.Sum(selector);
        }
        public static float? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return source.Sum(selector);
        }
        public static float Sum<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return source.Sum(selector);
        }
        public static int? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return source.Sum(selector);
        }
        public static int Sum<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return source.Sum(selector);
        }
        public static long? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return source.Sum(selector);
        }
        public static long Sum<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return source.Sum(selector);
        }
    }
