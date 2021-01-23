    public class Remote : IRemote
    {
      private IObservable<IMessage> _messages = ...;
      public IObservable<IMessage> Message {
        get {
          return message;
        }
      }
    }
