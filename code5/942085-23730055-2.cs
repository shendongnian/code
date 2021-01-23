     class Program
        {
            public static async Task GetStuffParallelForEach()
            {
                var data = Enumerable.Range(1, 10);
                Parallel.ForEach(data, async i =>
                {
                    await Task.Delay(1000 * i);
                    Console.WriteLine(i);
                });
            }
    
            public static async Task GetStuffForEachAsync()
            {
                var data = Enumerable.Range(1, 10);
                await data.ForEachAsync(5, async i =>
                {
                    await Task.Delay(1000 * i);
                    Console.WriteLine(i);
                });
                
            }
    
            static void Main(string[] args)
            {
                //GetStuffParallelForEach().Wait(); // Finished printed before work is complete
                GetStuffForEachAsync().Wait(); // Finished printed after all work is done
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
