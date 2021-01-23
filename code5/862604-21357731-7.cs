    public static void MyMethod<T>(IEnumerable<T> enumerable)
    {
        foreach (var dynObj in enumerable)
        {
            var typeInterfaces = dynObj.GetType().GetInterfaces();
            if (typeInterfaces.Contains(typeof(IInterface))) {
                // Something
            }
            else if(typeInterfaces.Contains(typeof(IAnotherInterface))) {
                // Something Else
            }
        }
    }
