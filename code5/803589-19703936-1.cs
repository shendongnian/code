    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Task.Delay(1000)
                    .ContinueWith(t => Program.throwsException());
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine("Catched"); // wont happen
                }
    
            }
            static void throwsException()
            {
                Console.WriteLine("Method started");
                throw new Exception("thrown"); // Unhandled exception
            }
        }
