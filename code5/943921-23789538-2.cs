    public interface IRemote
    {
      public IObservable<IMessage> Messages { get; }
      public IDisposable Connect();
    }
    public class Remote : IRemote
    {
      private IObservable<IMessage> _messages = ...;
      private IObservable<IMessage> _connectableMessages
        = this._messages
            .Publish();
      public IObservable<IMessage> Message {
        get {
          return this._connectableMessages;
        }
      }
      public IDisposable Connect()
      {
        return this._connectableMessages.Connect();
      }
    }
