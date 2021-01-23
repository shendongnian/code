    currentMethodStartingTheThread()
    {
       Thread t = new Thread(new ThreadStart( CallAsParameterized() );
    }
    
    void CallAsParameterized()
    {
       int value = 123;
       fail.DoWork(value);
    }
    
    
    Class fail
    {
      public void DoWork(int Value)
      { do whatever with the parameter value )
    }
