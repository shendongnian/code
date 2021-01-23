    class Logger
    {
        BlockingCollection<IMessage> _queue;
        Thread _loggingThread;
        public Logger(BlockingCollection<IMessage> queue)
        {
            _queue = queue;
            _loggingThread = new Thread(LoggingThreadProc);
        }
        private void LoggingThreadProc(object state)
        {
            IMessage msg;
            while (_queue.TryTake(out msg, TimeSpan.Infinite))
            {
                // log the item
            }
        }
    }
