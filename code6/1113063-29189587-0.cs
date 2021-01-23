        static void Main(string[] args)
        {
            List<ConsoleKeyInfo> userInput = new List<ConsoleKeyInfo>();
            var userInputTask = Task.Run(() =>
                {
                    while (true)
                        userInput.Add(Console.ReadKey(true));
                });
            userInputTask.Wait(5000);
            string userInputStr = new string(userInput.Select(p => p.KeyChar).ToArray());
            Console.WriteLine("Time's up: you pressed '{0}'", userInputStr);
            Console.ReadLine();
        }
