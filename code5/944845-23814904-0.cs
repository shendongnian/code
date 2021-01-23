    internal class ClaseBase<T>
    {
        public T BaseValue { get; set; }
    }
    internal class SubclaseGenerica<T> : ClaseBase<long>
    {
        public T DerivedValue { get; set; }
    }
