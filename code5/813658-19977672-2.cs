        class WhenAny
        {
            public static async Task<string> GetFirstToRespondAsync()
            {
                // Call two web services; take the first response.
                Task<string>[] tasks = new[] { Task1(), Task2() };
 
                // Await for the first one to respond.
                Task<string> firstTask = await Task.WhenAny(tasks);
                // Return the result.
                return firstTask.Result;
            }
            private static async Task<string> Task1()
            {
                await Task.Delay(3000);
                return "Task1";
            }
            private static async Task<string> Task2()
            {
                await Task.Delay(1000);
                return "Task2";
            }
        }
    Call that from the Main function as follows:
        static void Main(string[] args)
        {
            var t = WhenAny.GetFirstToRespondAsync();
            t.ContinueWith((taskName) =>
                {
                    string result = taskName.Result;
                    Console.WriteLine("Result: " + result);
                });
            t.Wait();
            Console.ReadLine();
        }
    That should return the task that completes first, and you can access that information from the `Task.Result`
