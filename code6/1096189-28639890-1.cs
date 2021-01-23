        private int _index = -1; // -1 so first request starts at 0
        private bool _shouldContinue = true;
        public IEnumerable<RequestStuff> GetAllData()
        {
            var tasks = new List<Task<RequestStuff>>();
            while (_shouldContinue)
            {
                tasks.Add(new Task<RequestStuff>(() => GetDataFromService(GetNextIndex())));
            }
            Task.WaitAll(tasks.ToArray());
            return tasks.Select(t => t.Result).ToList();
        }
        private RequestStuff GetDataFromService(int id)
        {
            // Get the data
            // If there's no data returned set _shouldContinue to false
            // return the RequestStuff;
        }
        private int GetNextIndex()
        {
            return Interlocked.Increment(ref _index);
        }
