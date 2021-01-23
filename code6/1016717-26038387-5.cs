    public class DoSomeWorkLogger : IDoSomeWork, IDecorator<IDoSomeWork>
    {
        public void Execute()
        {
            var sw = Stopwatch.StartNew();
            this.Inner.Execute();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        public IDoSomeWork Inner { get; set; }
    }
