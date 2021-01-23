    private void HelloMessageHandler(      HelloMessage      msg ) { ... }
    private void GoodByeMessageHandler(    GoodByeMessage    msg ) { ... }
    private void HowYaDoingMessageHandler( HowYaDoingMessage msg ) { ... }
    .
    .
    .
    public Action<T> GetHandler<T>()
    {
      Type t = typeof(T) ;
      Delegate handler ;
      
      if      ( t == typeof(HelloMessage)      ) handler = (Action<HelloMessage>)      HelloMessageHandler      ;
      else if ( t == typeof(GoodByeMessage)    ) handler = (Action<GoodByeMessage>)    GoodByeMessageHandler    ;
      else if ( t == typeof(HowYaDoingMessage) ) handler = (Action<HowYaDoingMessage>) HowYaDoingMessageHandler ;
      else
      {
        string message =  string.Format( "Unknown Message Type specified: {0}" , t.FullName ) ;
        throw new InvalidOperationException(message);
      }
      
      Action<T> instance = (Action<T>) handler ;
      return instance ;
    }
