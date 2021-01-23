    public void myMethod(IEnumerable<T> enumerable)
    {
        var typeInterfaces = typeof(T).GetInterfaces();
        if (typeInterfaces.Contains(typeof(IInterface))) {
            // Something
        }
        else if(typeInterfaces.Contains(typeof(IAnotherInterface))) {
            // Something Else
        }
    }
