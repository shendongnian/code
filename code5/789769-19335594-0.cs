        static async Task Method()
        {
            await DoSomeProcess();
            Console.WriteLine("All Methods have been executed");
        }
        static async Task DoSomeProcess()
        {
            await Task.Delay(3000);
        }
