    class Program
    {
        public static void Main(string[] args)
        {
            Observable.Merge(
                    // Async / Await
                    (
                        (Func<Task<string>>)
                        (async () => { await Task.Delay(250); return "async await"; })
                    )().ToObservable(),
                    // FromResult
                    Task.FromResult("FromResult").ToObservable(),
                    // Run
                    Task.Run(() => "Run").ToObservable()
                )
                .Subscribe(Console.WriteLine);
            Console.ReadLine();
        }
    }
