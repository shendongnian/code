    class SpecialMessageHandle implements IHandle<SpecialMessage> {
      public Class<SpecialMessage> getClass() { return SpecialMessage.class; }
     
      public handle( SpecialMessage message ) { ... }
    }
