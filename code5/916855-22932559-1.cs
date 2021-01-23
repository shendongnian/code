    void MyMethod<T1,T2>(Tuple<T1, T2> data)
    {
        // In case ToString() is overridden
        Console.WriteLine("Datatype = Tuple<{0}, {1}>",
            typeof(T1).Name,
            typeof(T2).Name);
    }
    void MyMethod(MyObj data)
    {
        Console.WriteLine("Datatype = MyObj");
    }
    void MyMethod(int data)
    {
        Console.WriteLine("Datatype = System.Int32");
    }
