    public IEnumerable<Type> Alternate()
    {
        return new [] 
        {
            MyClassA.GetType(),
            MyClassB.GetType()
        }
    }
