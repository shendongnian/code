    public class Lottery
    {
        public HashSet<int> _previousNumbers = new HashSet<int>();
        private Random random = new Random();
    
        public int GetNextNumber()
        {
            int next;
            do
            {
                next = random.Next();
            }
            while (_previousNumbers.Contains(next));
            _previousNumbers.Add(next);
            return next;
        }
    
    }
