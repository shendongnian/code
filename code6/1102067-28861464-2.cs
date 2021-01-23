        public static void Main()
        {
            Launch();
        }
        public static async void Launch()
        {
            Console.WriteLine("Hello!! welcome to task application");
            Console.ReadKey();
            Console.WriteLine(await GetMessage());
            Console.ReadKey();
        }
        public static Task<string> GetMessage()
        {
            return Task.Factory.StartNew<string>(() =>
                {
                    return "Good Job";
                });
        }
