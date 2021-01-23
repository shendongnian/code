        /// <summary>
        /// Used to tell the thread to exit.
        /// </summary>
        private readonly AutoResetEvent _eventDelay;
        /// <summary>
        /// True if the worker thread is running.
        /// </summary>
        private bool _isRunning;
