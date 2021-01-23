    public void Foo()
    {
        var method = System.Reflection.MethodInfo.GetCurrentMethod();
        Log.Log(string.Format("I is inside of {0}", method.Name));
    }
