    class Program
    {
        static void Main(string[] args)
        {
            var valueType = 100;
            var referenceType = new IntWrapper(100);
            var stopWatch = Stopwatch.StartNew();
            int assignee;
            for (int i = 0; i < 500000000; i++)
            {
                assignee = valueType;
            }
            stopWatch.Stop();
            Console.WriteLine("Accessed valueType 500m times in {0}ms", stopWatch.ElapsedMilliseconds);
            stopWatch.Restart();
            for (int i = 0; i < 500000000; i++)
            {
                assignee = referenceType.IntAccessor;
            }
            stopWatch.Stop();
            Console.WriteLine("Accessed referenceType 500m times in {0}ms", stopWatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
    public class IntWrapper
    {
        private readonly int _intField;
        public IntWrapper(int i)
        {
            _intField = i;
        }
        public int IntAccessor
        {
            get { return _intField; }
        }
    }
