    public int A()
    {
        using(IDisposable obj = new MyClass())
        {
            //...
            return something;
        }
    }
