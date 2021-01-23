    class ImmutableHolder<T>
    {
      T value;
      public T Value { get { return value; } ; 
      public ImmutableHolder(T v) {value = v;}
      override public bool Equals(Object o) {
        var other = o as ImmutableHolder<T>;
        if (!other) return false;
        return Object.Equals(value,other.value);
      }
      override public int GetHashCode() { return Object.GetHashCode(value); }
    }
