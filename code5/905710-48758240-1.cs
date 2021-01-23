    class Program { 
        static void Main(string[] args) {
            // outputs Program.Main
            Console.WriteLine(GetMethodContextName());
            Test().Wait();
        }
        static async Task Test() { 
            // outputs Program.Test
            Console.WriteLine(GetMethodContextName());
            await Task.CompletedTask;
        }
    }
