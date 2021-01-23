    static void Main(string[] args)
        {
            var task = GetNameAsync();
            task.Wait();
            var result = task.Result;
            Console.WriteLine(result);
        }
        static async Task<string> GetNameAsync()
        {
            var first = FetchFirstNameAsync();
            var second = FetchLastNameAsync();
            Console.WriteLine("I'm the first, bitch...");
            await Task.WhenAll(first, second);
            return first.Result + " " + second.Result;
        }
        private static async Task<string> FetchFirstNameAsync()
        {
            Console.WriteLine("entered1");
            return await Task.Factory.StartNew(() =>
            {
                var counter = 0;
                for (var index = 0; index < 20000; index++)
                {
                    Task.Delay(1);
                    counter++;
                    Console.WriteLine("handled1");
                }
                return counter.ToString(CultureInfo.InvariantCulture) + "First";
            });
        }
        private static async Task<string> FetchLastNameAsync()
        {
            Console.WriteLine("entered1");
            return await Task.Factory.StartNew(() =>
            {
                var counter = 0;
                for (var index = 0; index < 20000; index++)
                {
                    Task.Delay(1);
                    counter++;
                    Console.WriteLine("handled2");
                }
                return counter.ToString(CultureInfo.InvariantCulture) + "Last";
            });
        }
