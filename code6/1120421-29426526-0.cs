    public void GenericMethod<T>(IEnumerable<T> items)
        where T : IMyInterface
    {
        for(var item in items)
        {
           // how can I get the item.GetKey();
        }
    }
