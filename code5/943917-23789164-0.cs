    void Main()
    {
        var networkStream = new NetworkStream();
        var remote = new Remote(networkStream);
        remote.GetMessages().Dump("remote.GetMessages()");
    }
    
    // Define other methods and classes here
    public class NetworkStream
    {
        //Fake getting bytes off the wire or disk
        public IObservable<byte> GetNetworkStream()
        {
            var text = @"Line 1.
    Hello line 2.
    3rd and final line!";
            
            return Observable.Zip(
                UTF8Encoding.UTF8.GetBytes(text).ToObservable(),
                Observable.Interval(TimeSpan.FromMilliseconds(100)),
                (character, time)=>character);
        }
    }
    public interface IMessage
    {
        string Content {get;}
    }
    public class Message : IMessage
    {
        public Message(string content)
        {
            Content = content;
        }
        public string Content {get; private set;}
    }
    public interface IRemote
    {
        IObservable<IMessage> GetMessages();
    }
    public class Remote : IRemote
    {
        private readonly NetworkStream _networkStream;
        private readonly byte[] _delimiter = UTF8Encoding.UTF8.GetBytes(Environment.NewLine);
        public Remote(NetworkStream networkStream)
        {
            _networkStream = networkStream;
        }
        public IObservable<IMessage> GetMessages()
        {
        return  _networkStream.GetNetworkStream()
                                .WindowByExclusive(b => _delimiter.Contains(b))
                                .SelectMany(window=>window.ToArray().Select(bytes=>UTF8Encoding.UTF8.GetString(bytes)))
                                .Select(content=>new Message(content));
        }
        //TODO Add IDispose and clean up your NetworkStream
    }
    
    public static class ObservableEx
    {
        public static IObservable<IObservable<T>> WindowByExclusive<T>(this IObservable<T> input, Func<T, bool> isWindowBoundary)
        {
            return Observable.Create<IObservable<T>>(o=>
            {
                var source = input.Publish().RefCount();
                var left = source.Where(isWindowBoundary).Select(_=>Unit.Default).StartWith(Unit.Default);
                return left.GroupJoin(
                                source.Where(c=>!isWindowBoundary(c)),
                                x=>source.Where(isWindowBoundary),
                                x=>Observable.Empty<Unit>(),
                                (_,window)=>window)
                            .Subscribe(o);
            });
        }
    }
