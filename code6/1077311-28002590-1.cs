    public class Program
    {
        private const int NumOfObjects = 100;
        private const int NumOfThreads = 10000;
        public static void Main(string[] args)
        {
            var objects = new List<Object>();
            for (var i = 0; i < NumOfObjects; i++) {
                objects.Add(new object());
            }
            var tasks = new Task[NumOfThreads];
            var objectStack = new ObjectStack(objects);
            for (var i = 0; i < NumOfThreads; i++)
            {
                var task = new Task(objectStack.ThreadUnsafeMultiPop);
                tasks[i] = task;
            }
            for (var i = 0; i < NumOfThreads; i++)
            {
                tasks[i].Start();
            }
            //Using this seems to throw exceptions from unit test context
            //Parallel.For(0, NumOfThreads, x => objectStack.ThreadUnsafeMultiPop());
    }
