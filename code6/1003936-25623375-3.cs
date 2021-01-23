    class Handle<T> implements IHandle<T> {
      Class<T> messageClass;
  
      public Handle( Class<T> msgClass ) { messageClass = msgClass; }
  
      public Class<T> getMessageType() { return messageClass; }
      public handle( T message ) { ... }
    }
