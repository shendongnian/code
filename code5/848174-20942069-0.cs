    class Program
    {
        static void Main(string[] args)
        {
            Task<string> str = returnStringAsync();
            Console.WriteLine("hello!");
            
            string name = str.Result;
            Console.WriteLine(name);
        }
        static async Task<string> returnStringAsync()
        {
            await Task.Delay(5000);
            return "Richard"; 
        }
    }
