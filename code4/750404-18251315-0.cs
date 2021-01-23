    interface A
    {
      int method1(float x);
    }
    class AImpl : A
    {
        public int method1(float x) { }
    }
    class LoggedAImpl : A
    {
    private AImpl innerA;
    public int method1(float x) 
    {
      //log method and parameters
      int result;
      try
      {
        result = innerA.method1(x);
      }
      finally
      {
        //log method exit
      }
    }
    }
