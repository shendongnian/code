    public static class Extensions
    {
        private static readonly MethodInfo SetAggregateInternalMethod = typeof(Extensions)
            .GetMethod("SetAggregateInternal", BindingFlags.Static | BindingFlags.NonPublic);
    
        private static void SetAggregateInternal<TAggregate>(object item, TAggregate value) where TAggregate : IAggregate
        {
            var aggregateCommand = item as IUpdateAggregateCommand<TAggregate>;
            if (aggregateCommand != null)
                aggregateCommand.Entity = value;
        }
    
        public static void TrySetAggregate(object item, IAggregate value)
        {
            SetAggregateInternalMethod
                .MakeGenericMethod(value.GetType())
                .Invoke(null, new[] { item, value });
        }
    }
