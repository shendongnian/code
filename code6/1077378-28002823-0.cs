    private Dictionary<int, MyClass> myDict = new Dictionary<int, MyClass>();
    void Check(int value)
    {
        MyClass target = null;
        myDict.TryGetValue(value, out target);
        //target.Image = etc.
    }
