    /// <summary>
    /// Abstract base class for Service Clients wishing to utilise an API
    /// via some service contract channel.
    /// </summary>
    public abstract class ServiceClient<T> : IDisposable where T : class {
        /// <summary>
        /// Creates and configures the ServiceClient and opens the connection
        /// to the API via its Channel.
        /// </summary>
        protected ServiceClient(EndpointAddress endpoint, Binding binding) {
            this.ServiceChannel = ChannelFactory<T>.CreateChannel(binding, endpoint);
            (this.ServiceChannel as ICommunicationObject).Open();
        }
        /// <summary>
        /// Closes the client connection.
        /// </summary>
        public void Close() {
            (this.ServiceChannel as ICommunicationObject).Close();
        }
        
        /// <summary>
        /// Releases held resources.
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Closes the client connection and releases any additional resources.
        /// </summary>
        protected virtual void Dispose(bool disposing) {
            if (disposed) return;
            if (disposing) {
                if (this.ServiceChannel != null) {
                    this.Close();
                    this.ServiceChannel = null;
                    this.disposed = true;
                }
            }
        }
        /// <summary>
        /// Provides a derived class access to the API via a dedicated channel.
        /// </summary>
        protected T ServiceChannel { get; private set; }
        
        /// <summary>
        /// Indicates if this instance has been disposed.
        /// </summary>
        private bool disposed = false;
    }
    
