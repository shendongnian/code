    class SpecialMessageHandle implements IHandle<SpecialMessage> {
      public Class<SpecialMessage> getMessageType() { return SpecialMessage.class; }
     
      public handle( SpecialMessage message ) { ... }
    }
