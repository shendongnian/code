    public class Service
    {
        private int _called = 0;
        private Task<int> _asyncTask;
        public Task<int> DoAsync()
        {
            if (!IsFinished)
                return _asyncTask;
            _asyncTask = Task.Run(() => Do());
            return _asyncTask;
        }
        private bool IsFinished
        {
            get
            {
                return _asyncTask == null ||
                       _asyncTask.IsCompleted ||
                       _asyncTask.IsCanceled ||
                       _asyncTask.IsFaulted;
            }
        }
        private int Do()
        {
            System.Threading.Thread.Sleep(200); // fake business.
            return ++_called;
        }
    }
