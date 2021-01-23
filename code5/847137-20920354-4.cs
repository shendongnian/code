    internal class MaxValueCache
    {
        private static readonly Dictionary<Type, object> maxValues = new Dictionary<Type, object>()
        {
            { typeof(int), int.MaxValue},
            { typeof(long), long.MaxValue}
            //...
        };
        public static object GetMaxValue(Type type)
        {
            return maxValues[type];
        }
    }
