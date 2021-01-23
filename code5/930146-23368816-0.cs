    public  class MultiplexerBase<T> : CommunicationObject, IMultiplexer<T>
        where T: IMessage
    {
        BufferBlock<T> _buffer;
        ActionBlock<T> _dispatcher;
        IOutputChannel<T> _channel;
        
        public MultiplexerBase(IOutputChannel<T> p_output)
        {
            _channel = p_output;
        }
        public IOutputChannel<T> UnderlyingChannel { get { return _channel; } }
        public Task SendAsync(T p_frame)
        {
            return _buffer.SendAsync(p_frame);
        }
        public Task SendAsync(T p_frame, CancellationToken p_ct)
        {
            return _buffer.SendAsync(p_frame,p_ct);
        }
        protected override void OnOpen()
        {
            _buffer = new BufferBlock<T>();
            _dispatcher = new ActionBlock<T>(m => _channel.Send(m));
            _buffer.LinkTo(_dispatcher);
        }
        protected override void OnClose()
        {
            _buffer.Complete();
            _buffer = null;
            _dispatcher = null;
        }
   }
