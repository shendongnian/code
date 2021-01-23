    static Obejct lockThis = new Object();
    public void DoSomething()
    {
     
       lock(lockThis)
       {
          //trying to step through code
       }
    }
