    class WhenAll
    {
        public static async Task<string[]> WaitForAllAsync()
        {
            // Call two web services; take the first response.
            Task<string>[] tasks = new[] { Task1(), Task2(), Task3() };
            // Wait for a tasks
            string[] results = await Task.WhenAll(tasks);
            // Return the result.
            return results;
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
        private static async Task<string> Task3()
        {
            await Task.Delay(5000);
            return "Task3";
        }
    }
