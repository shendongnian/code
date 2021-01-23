    bool _isConnected;
    bool isConnected
    {
      get { return _isConnected; }
      set {
        if (value != _isConnected) //it's changing!
        {
          doSomething();
        }
    
        _isConnected = value; //Could do this inside the if but I prefer it outside because some types care about assignment even with the same value.
      }  
    }
