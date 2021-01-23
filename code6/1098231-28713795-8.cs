    List<A> list = new List<A>();
    A obj = new A();
    obj.num = 0;
    
    for (int i = obj.num; i < 10; ++i)
    {
        var clonedObj = obj.Clone() as A; // cast to be able to add in the collection
        clonedObj.num = i;
        list.Add(clonedObj);
    }
