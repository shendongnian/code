    private bool _MyNameHasBeenRead = false;
    
    string MyName
    {
        get 
        {
            if(_MyNameHasBeenRead)
                    throw new Exception("Can't read MyName twice");
            _MyNameHasBeenRead = true;
            Thread.Sleep(10000);
    	    return "HELLO";
        }
    }
