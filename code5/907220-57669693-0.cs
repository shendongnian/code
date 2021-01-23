    private static void Main()
        {
            RecursiveMethod().Wait();
        }
        private static async Task RecursiveMethod()
        {
            await Task.Delay(1);
            //await Task.Yield(); // Uncomment this line to prevent stackoverlfow.
            await RecursiveMethod();
        }
