    static void Main(string[] args)
        {
            System.Threading.Tasks.Task.Run(() => MainAsync(args)).Wait();
        }
        static async void MainAsync(string[] args)
        {
          //rest of code
