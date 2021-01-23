    public delegate object GetObject();
    public event GetObject MyEvent;
    
    public IList<object> RaiseMyEvent()
    {
        var myList = new List<object>();
        if (MyEvent != null)
            foreach (var handler in MyEvent.GetInvocationList())
                myList.Add(handler.DynamicInvoke());
        return myList;
    }
