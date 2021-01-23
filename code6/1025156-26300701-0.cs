    static void Main(string[] args)
            {
                Program p = new Program();
                p.ParallelThings();
            }
    
    
            Processor GetMyProcessor()
            {
                Processor processor = new Processor();
                // Some initialization
                return processor;
            }
    
            void ParallelThings()
            {
                IEnumerable<MyClass> myData = new List<MyClass>() { new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass()
        ,new MyClass(),new MyClass(),new MyClass(),new MyClass(),new MyClass(),new MyClass()};
                Parallel.ForEach(
                        myData,
                        new ParallelOptions { MaxDegreeOfParallelism = 8 },
                        GetMyProcessor,
                        (data, state, processor) =>
                        {
                            //  Console.WriteLine(DateTime.Now);
                            return processor.DoSomething(); // <---- NO exception
                        },
                        (item) => { } //Nothing to do for the moment
                  );
            }
