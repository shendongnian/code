        public async Task<AsyncOutResult<bool, string>> TryReceiveAsync()
        {
            string message;
            bool success;
            // ...
            return new AsyncOutResult<bool, string>(success, message);
        }
