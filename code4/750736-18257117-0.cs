    interface ILog {
       public void Log();
    }
    public DebugLog : ILog {
      public DebugLog(Debug d) {} //ctor that takes Debug Object
      public void Log(){}
    }
    
    public WindowLog : ILog {
      public WindowLog(Text t) {} //ctor that takes window log
      public void Log(){}
    }
