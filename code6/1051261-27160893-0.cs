    public static class MessagePropertiesHelper
    {
      private static Func<MessageProperties> _current = () => OperationContext.Current.IncomingMessageProperties;
    
    
      public static MessageProperties Current
      {
          get { return _current(); }
      }
    
      public static void SwitchCurrent(Func<MessageProperties> messageProperties)
      {
          _current = messageProperties;
      }
    
    }
