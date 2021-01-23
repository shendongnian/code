    public static void MyMethod<T>(IEnumerable<T> enumerable)
    {
        var allInterfaces = enumerable.SelectMany(e => e.GetType().GetInterfaces()).ToList();
        if (allInterfaces.Contains(typeof(ITheFirstInterface)))
        {
            Console.WriteLine("Has The First Interface");
        }
            
        if (allInterfaces.Contains(typeof(ITheSecondInterface)))
        {
            Console.WriteLine("Has The Second Interface");
        }
    }
