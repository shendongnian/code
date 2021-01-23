    void DoSomething() 
    {
        var theList = new List<IService>();
        for (int i = 1; i <= 3; i++)
        {
            IService s = createService(i); // Invoke the provided factory method
            theList.Add(s);
        }
        // do something with the list...
    }
