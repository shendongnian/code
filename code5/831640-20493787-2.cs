    using System;
    // other usings
    using tAlias = System.Threading;
    
    
    public void Sample()
    {
       var thread = new tAlias.Thread( () => { Trace.WriteLine(" demo that thread works"); });
       tAlias.Thread.Sleep(10);
    }
