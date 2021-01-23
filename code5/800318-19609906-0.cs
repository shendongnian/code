    public sealed class MessageProcessor : IDisposable
    {
        public MessageProcessor() 
            : this(-1)
        {   
        }
    
        public MessageProcessor(int maxThreadsForProcessing)
        {
            _maxThreadsForProcessing = maxThreadsForProcessing;
            _messages = new BlockingCollection<Message>();
            _cts = new CancellationTokenSource();
    
            _messageProcessorThread = new Thread(ProcessMessages);
            _messageProcessorThread.IsBackground = true;
            _messageProcessorThread.Name = "Message Processor Thread";
            _messageProcessorThread.Start();
        }
    
        public int MaxThreadsForProcessing
        {
            get { return _maxThreadsForProcessing; }
        }
    
        private readonly BlockingCollection<Message> _messages;
        private readonly CancellationTokenSource _cts;
        private readonly Thread _messageProcessorThread;
        private bool _disposed = false;
        private readonly int _maxThreadsForProcessing;
    
        /// <summary>
        /// The background thread that processes messages in the system
        /// </summary>
        private void ProcessMessages()
        {
            try
            {
                Parallel.ForEach(_messages.GetConsumingEnumerable(),
                             new ParallelOptions()
                             {
                                 CancellationToken = _cts.Token,
                                 MaxDegreeOfParallelism = MaxThreadsForProcessing
                             },
                             ProcessMessage);
            }
            catch (OperationCanceledException)
            {
                //Don't care that it happened, just don't want it to bubble up as a unhandeled exception.
            }
        }
    
        private void ProcessMessage(Message message, ParallelLoopState loopState)
        {
            //Here be dragons! (or your code to process a message, your choice :-))
            
            //Use if(_cts.Token.IsCancellationRequested || loopState.ShouldExitCurrentIteration) to test if 
            // we should quit out of the function early for a graceful shutdown.
        }
    
        /// <summary>
        /// Signals the system to stop processing messages.
        /// </summary>
        /// <param name="finishQueue">Should the queue of messages waiting to be processed be allowed to finish</param>
        public void Stop(bool finishQueue = true)
        {
            _messages.CompleteAdding();
            if(!finishQueue)
                _cts.Cancel();
    
            //Wait for the message processor thread to finish it's work.
            _messageProcessorThread.Join();
        }
        
        public void ReceiveMessage(Message message)
        {
           _messages.Add(message);
        }
    
        public void Dispose()
        {
            if(!_disposed)
            {
                if(_cts != null && _messages != null && _messageProcessorThread != null)
                    Stop();
                if(_cts != null)
                    _cts.Dispose();
                if(_messages != null)
                    _messages.Dispose();
                GC.SuppressFinalize(this);
               _disposed = true;
            }
        }
    
        ~MessageProcessor()
        {
            //Nothing to do, just making FXCop happy.
        }
    
    }
