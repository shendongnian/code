    interface INullableWrapper
    {
        bool HasValue { get; }
        object Value { get; } // Careful: boxing!
    }
    class NullableWrapper<T> : INullableWrapper
        where T : struct
    {
        public T? Nullable { get; private set; }
        public bool HasValue { get { return this.Nullable.HasValue; } }
        object INullableWrapper.Value { get { return this.Nullable.Value; } }
        public T Value { get { return this.Nullable.Value; } }
        public NullableWrapper(T? nullable)
        {
            this.Nullable = nullable;
        }
    }
    return new INullableWrapper[] { new NullableWrapper<int>(5), new NullableWrapper<string>("Hello") };
