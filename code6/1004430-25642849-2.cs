    class ExpensiveConstructionObject
    {
        public ExpensiveConstructionObject()
        {
            Console.WriteLine("Executing the expensive constructor...");
        }
        public void Do(string stuff)
        {
            Console.WriteLine("Doing: " + stuff);
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            var pool = new Pool<ExpensiveConstructionObject>(() => new ExpensiveConstructionObject());
            var t1 = pool.Get();
            t1.WrappedObject.Do("task 1");
            using (var t2 = pool.Get())
                t2.WrappedObject.Do("task 2");
            using (var t3 = pool.Get())
                t3.WrappedObject.Do("task 3");
            t1.Dispose();
            Console.ReadLine();
        }
    }
