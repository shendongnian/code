        static void Main(string[] args)
        {
            Console.WriteLine("HELLO WORD");
            var t1 = Task.Factory.StartNew(new Func<Task>(async () => await Method())).Unwrap();
            Console.WriteLine("START");
            t1.Wait();
            Console.WriteLine("COMPLETED");
            Console.ReadKey();
        }
        static async Task Method()
        {
            Console.WriteLine("BEFORE DELAY");
            await Task.Delay(1000);
            Console.WriteLine("AFTER DELAY");
        }
