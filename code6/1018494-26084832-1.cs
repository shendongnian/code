    private List<IAddable> list = new List<IAddable>();
    public void Add (IAddable obj)
    {
        Console.WriteLine("Added {0} to the Examp class", obj);
        list.Add(obj); // actually add the object to some collection
        obj.add();
    }
