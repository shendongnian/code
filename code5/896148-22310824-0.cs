    public void Gogogo()
    {
        if Monitor.TryEnter(this.locker)
        { 
             try 
             { 
                  // Do stuff
             } 
             finally 
             {
                Monitor.Exit(this.locker); 
             } 
        }
        else
           return;
        // rest of method
    }
