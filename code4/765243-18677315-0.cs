    interface ICheckIfContained
      { bool Contains(object it); }
    interface ICheckIfContained<in T> : ICheckIfContained
      { bool Contains(T it); }
    interface IDictionary<in TKey, out TValue> : ICheckIfContained<TKey> ...
