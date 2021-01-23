    watch.Start();
    var t1 = Task.Factory.StartNew(MyMethod1);
    var t2 = Task.Factory.StartNew(MyMethod2);
    Task.Factory.ContinueWhenAll(new [] {t1, t2}, tasks => watch.Stop())
    
