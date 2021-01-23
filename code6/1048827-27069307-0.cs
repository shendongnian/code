    private readonly object _syncObject = new object();
    .....
    private void ProcessingMethod(){
       
        if(Monitor.TryEnter(_syncObject))
        {
           try{
                  //do some processing.
           }
           finally{
              Monitor.Exit(_syncObject);
           }
        }          
    }
