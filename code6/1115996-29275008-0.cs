    static void AddSomeInstances<T>(List<T> list) where T : new()
    {
        T newItem = new T();
        list.Add(newItem);
    }
    static void Main(String[] args)
    {
        List<int> test = new List<int>();
        // 0
        Console.WriteLine(test.Count);
        AddSomeInstances(test);
        // 1
        Console.WriteLine(test.Count);
    }
