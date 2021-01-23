    class GlobalQueue
    {
        private readonly List<IMyTask> _subscribers=new List<IMyTask>();
        public void Subscribe(IMyTask task)
        {
            _subscribers.Add(task);
        }
        public void Unsubscribe(IMyTask task)
        {
            _subscribers.Remove(task);
        }
        public void Enqueue(List<SymbolsTable> table)
        {
            foreach (var s in _subscribers)
                s.Enqueue(table);
        }
    }
    interface IMyTask
    {
        void Enqueue(List<SymbolsTable> table);
    }
