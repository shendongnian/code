    static Action<int> GetWorker()
    {
        int count = 0;
    
        return k => k == 0 ? 
                 Console.WriteLine("Working 1 - {0}",count++) : 
                 Console.WriteLine("Working 2 - {0}",count++);
    }
    
    ...
    var x = GetWorker();
    foreach(var i in Enumerable.Range(0,4))
    {
        x(0); x(1);
    }    
    // or maybe
    var y = GetWorker();
    // and now we refer to the same closure
    Action x1 = () => y(0);
    Action x2 = () => y(1);
    foreach(var i in Enumerable.Range(0,4))
    {
        x1(); x2(); 
    }
