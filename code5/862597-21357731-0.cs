    public void myMethod(IEnumerable<T> enumerable)
    {
        if (typeof(T).GetInterfaces().Contains(typeof(IInterface))) {
            // Something
        }
    }
