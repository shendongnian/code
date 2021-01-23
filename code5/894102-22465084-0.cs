    [Test]
    public void GetterVsField()
    {
        PropertyTest propertyTest = new PropertyTest();
        Stopwatch stopwatch = new Stopwatch();
    
        stopwatch.Start();
        propertyTest.LoopUsingCopy();
        stopwatch.Stop();
        Console.WriteLine("Using copy: " + stopwatch.ElapsedMilliseconds / 1000.0);
    
        stopwatch.Reset();
        stopwatch.Start();
        propertyTest.LoopUsingGetter();
        stopwatch.Stop();
        Console.WriteLine("Using getter: " + stopwatch.ElapsedMilliseconds / 1000.0);
   
        stopwatch.Reset();
        stopwatch.Start();
        propertyTest.LoopUsingField();
        stopwatch.Stop();
        Console.WriteLine("Using field: " + stopwatch.ElapsedMilliseconds / 1000.0);
    }
