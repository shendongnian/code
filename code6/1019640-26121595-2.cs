    // NOTE: I WOULD NOT USE THIS CODE
    // (preferring the Threading Library or async/await instead)
    static void Main(string[] args)
    {
        Task.Factory.StartNew(() => Console.WriteLine("Prepare"))
                    .ContinueWith(x => Work()).Unwrap()
                    .ContinueWith(x => Console.WriteLine(x.Result));
        Console.ReadLine();
    }
