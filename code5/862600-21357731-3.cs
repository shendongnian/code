    public static void MyMethod<T>(IEnumerable<T> enumerable)
    {
        foreach (var dynObj in enumerable)
        {
            var typeInterfaces = dynObj.GetType().GetInterfaces();
            if (typeInterfaces.Contains(typeof(ITheFirstInterface)))
            {
                Console.WriteLine("The First Interface");
            }
            else if (typeInterfaces.Contains(typeof(ITheSecondInterface)))
            {
                Console.WriteLine("The Second Interface");
            }
        }
    }
