    var data= SynchronizationContext.Current;
    
    
    Task t = Task.Run(() => {
       
        string sessionValue = null;
    
        data.Post(() => {
           
            sessionValue = HttpContext.Current.Session["value"];
        }
    
       
    });
