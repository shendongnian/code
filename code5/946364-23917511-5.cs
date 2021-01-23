    class Program
    {
        public static void Main(string[] args)
        {
            // We use a subject here since we don't have all of the tasks yet.
            var tasks = new Subject<Task<string>>();
            // Make up some tasks.
            var fromResult = Task.FromResult("FromResult");
            var run = Task.Run(() => "Run");
            Func<Task<string>> asyncAwait = async () => {
                await Task.Delay(250);
                return "async await";
            };
           
            // Merge any future Tasks into an observable, and subscribe.
            tasks.Merge().Subscribe(Console.WriteLine);
            // Send tasks.
            tasks.OnNext(fromResult);
            tasks.OnNext(run);
            tasks.OnNext(asyncAwait());
            Console.ReadLine();
        }
    }
