    public void DelegateTest()
    {
        var delList = new List<Delegate>();
        delList.Add(new KeyEventHandler(SomeFunction));
        delList.Add(new EventHandler(SomeFunction));
        foreach (var element in delList)
            element.DynamicInvoke(null, null);
    }
    
    public void SomeFunction(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Got called!");
    }
