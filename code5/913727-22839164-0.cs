    public async void caller() {
        var a = Method();   // <- The task is running now asynchronously
        Console.WriteLine("Please print it first"); // <- The line is printed.
        Console.WriteLine(await a); // <- the result of a is waited for and printed when available.
        Console.WriteLine("Please print it last");
    }
