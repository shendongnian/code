    public class Remote : IRemote
    {
      private IObservable<IMessage> _messages = ...;
      private IObservable<IMessage> _refCountedMessages
        = this._messages
            .Publish()
            .RefCount();
      public IObservable<IMessage> Message {
        get {
          return this._refCountedMessages;
        }
      }
    }
