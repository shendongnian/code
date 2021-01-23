    /// <summary>
    /// A wrapper around a client instance that is interested in
    /// the game events. It is observable, and when you observe the
    /// client, you can subscribe to the messages we receive from that
    /// client.
    /// </summary>
    public interface IClient : IObservable<IMessage>, IDisposable
    {
        /// <summary>
        /// Send the client a message.
        /// The client is responsible for encoding
        /// or decoding the message as necessary
        /// </summary>
        /// <param name="message"></param>
        void Send(IMessage message);
    }
    
    /// <summary>
    /// Some information that can be sent to either a remote
    /// client or a local client. This could be as simple as
    /// EventArgs, just make sure you can write a decoder/encoder
    /// for each of the types. The message types should derive
    /// from this interface
    /// </summary>
    public interface IMessage
    {
    
    }
    
    /// <summary>
    /// A class that can serialize or deserialize messages
    /// </summary>
    /// <typeparam name="TSerializedType"></typeparam>
    public interface IMessageSerializer<TSerializedType>
    {
        TSerializedType Encode(IMessage message);
    
        IMessage Decode(TSerializedType serialized);
    }
    
    /// <summary>
    /// This is a client located at a remote location (i.e,
    /// not at this server and we're connecting to it via a Tcp
    /// connection)
    /// </summary>
    public class RemoteClient : IClient
    {
        private readonly TcpClient _client;
    
        /// <summary>
        /// Creates the Remote client.
        /// </summary>
        /// <param name="client">The underlying .NET connection</param>
        /// <param name="serializer">The instance of IMessageSerializer that can
        /// serialize or deserialize messages</param>
        public RemoteClient(TcpClient client, IMessageSerializer serializer)
        {
            ....
        }
    
        public void Send(IMessage message)
        {
            var serialized = serializer.Encode(message);
            client.Write(serialized);
        }
    }
    
    /// <summary>
    /// This is the class you would use if you were connecting
    /// to no one and just wanted to route messages back to yourself
    /// </summary>
    public class LocalClient : IClient
    {
        /// <summary>
        /// Creates the local client
        /// </summary>
        /// <param name="messageQueue">An observer that is listening for messages.
        /// This is our message queue and it should be pointing at someone who
        /// is interested in consuming the messages (the game UI for example)</param>
        public LocalClient(IObserver<IMessage> messageQueue)
        {
        }
    
        public void Send(IMessage message)
        {
            messageQueue.OnNext(message);
        }
    }
