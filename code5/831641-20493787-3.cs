    using System;
    // other usings
    using tAlias = System.Threading;
    
    // use alias
    public void Sample()
    {
       var thread = new tAlias.Thread( () => { Trace.WriteLine(" demo that thread works"); });
       tAlias.Thread.Sleep(10);
    }
    // use full namespace 
    public void Sample()
    {
       var timer = new System.Threading.Timer( () => { Trace.WriteLine(" timer called"); });
       timer.Change(0,5000);
       System.Threading.Thread.Sleep(10);
    }
