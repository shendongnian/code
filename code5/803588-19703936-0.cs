     static void Main(string[] args)
            {
                Task.Delay(1000)
                .ContinueWith(t => Program.throwsException());
                Console.ReadKey();
            }
            static void throwsException()
            {
                Console.WriteLine("Method started");
            }
