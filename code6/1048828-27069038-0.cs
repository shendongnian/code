    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RemotingClient<T> : IDisposable
    {
        private bool _disposed;
        private readonly ChannelFactory<T> _factory;
        
        /// <summary>
        /// 
        /// </summary>
        public event OnCloseChannel ChannelClosed;
        public event OnFaultedChannel ChannelFaulted;
        /// <summary>
        /// 
        /// </summary>
        public delegate void OnCloseChannel();
        public delegate void OnFaultedChannel();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public RemotingClient(ChannelFactory<T> factory)
            : this(factory, SynchronizationContext.Current)
        {
        }
        private void OnClose(object sender, EventArgs e)
        {
            if (null != ChannelClosed)
                ChannelClosed();
        }
        private void OnFaulted(object sender, EventArgs e)
        {
            if (null != ChannelFaulted)
                ChannelFaulted();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="context"></param>
        public RemotingClient(ChannelFactory<T> factory, SynchronizationContext context)
        {
            Context = context;
            _factory = factory;
            CreateNewChannel();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiCallback"></param>
        public void PostToContext(SendOrPostCallback uiCallback)
        {
            Context.Post(uiCallback, null);
        }
        public void CreateNewChannel()
        {
            
                Channel = _factory.CreateChannel();
            
            ICommunicationObject c = Channel as ICommunicationObject;
            if (null == c)
                throw new ArgumentException(
                    typeof(T) + " Can not be used as an ICommunicationObject");
            c.Closed += OnClose;
            c.Faulted += OnFaulted;
            c.Open();
        }
        /// <summary>
        /// 
        /// </summary>
        public SynchronizationContext Context
        { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public T Channel
        { get; set; }
        public CommunicationState ChannelState
        {
            get
            {
                ICommunicationObject c = (ICommunicationObject)Channel;
                return c.State;
            }
        }
        #region IDisposable Members
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                    Close();
                this._disposed = true;
            }
                
        }
        public void Close()
        {
            ICommunicationObject c = Channel as ICommunicationObject;
            if (c.State == CommunicationState.Faulted)
                c.Abort();
            c.Close();
                
        }
        #endregion
    }
