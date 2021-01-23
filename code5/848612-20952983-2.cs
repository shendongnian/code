        /// <summary>
        /// Flags the job to shutdown. It will stop execution
        /// as soon as possible.
        /// </summary>
        public void ShutDown()
        {
            if (!_isRunning)
            {
                return;
            }
            _isRunning = false;
            _eventDelay.Set();
        }
