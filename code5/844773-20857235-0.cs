    class TransferredObject
    {
        private object _lockObject = new object();
        public void DoSomething()
        {
            lock(_lockObject)
            {
                // TODO: your code here...
            }
        }
    }
