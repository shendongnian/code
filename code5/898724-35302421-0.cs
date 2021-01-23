    public class Foo
    {
      private readonly IEnumerable<IMessageHandler> _messageHandlers
      public Foo(IEnumerable<IMessageHandler> messageHandlers)
      {
        _messageHandlers = messageHandlers;
      }
      
      public void Bar(message)
      {
        foreach(var handler in _messageHandlers)
        {
          handler.Handle(message)
        }
      }
    }
