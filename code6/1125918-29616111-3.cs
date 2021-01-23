    interface ITry<T>
    {
        bool HasValue { get; }
        T Value { get; }
        Exception Error { get; }
    }
