    List<A> list = new List<A>();
    A obj = new A();
    
    for (int i = 0; i < 10; ++i)
    {
        obj.num = i; // Assigns the current i to the num attribute inside obj
        var clonedObj = obj.Clone() as A; // cast to be able to add in the collection
        list.Add(clonedObj);
    }
