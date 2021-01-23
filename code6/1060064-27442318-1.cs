    public IEnumerator<T> GetEnumerator()
    {
        var leftEnumerable = (IEnumerable<T>)Left ?? new T[0];
        var rightEnumerable = (IEnumerable<T>)Right ?? new T[0];
        return leftEnumerable.Concat(new T[]{Value})
                             .Concat(rightEnumerable)
                             .GetEnumerator();
    }
   
