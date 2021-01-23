    public class ConsoleQueue
    {
        private readonly List<string> _values = new List<string>();
        public void FlushQueueIfFull()
        {
            if (_values.Count < 10) return;
            foreach (var value in _values)
            {
                Console.WriteLine(value);
            }
            _values.Clear();
        }
        public void Push(string message)
        {
            _values.Add(message);
            FlushQueueIfFull();
        }
    }
