     var context = HttpContext.Current;  
     var r = Task.Run( () => 
        {
           HttpContext.Current = context;
           return MyAsynchMethod(args);
        }
    ).Result;
        
