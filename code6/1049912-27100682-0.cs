    private static void Main(string[] args)
        {
            StartDoingNothingAsync();
            Console.WriteLine("test");
            Console.Read();
        }
        private static async void StartDoingNothingAsync()
        {
            await Task.Run(async delegate()
            {
                for (var i = 0; i < 5000; i++)
                {
                    //do something
                }
                Console.WriteLine("leaved");
            });
        }
