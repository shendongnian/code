    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.Read();
        }
        
        static async void Run()
        {
             await Gone();
        }
    
        static async void Gone()
        {
            for (int i = 0; i < 5; i++)
            {
                await Going();
                Console.WriteLine("Gone");
            }
        }
    
        static async void Going()
        {
            for (int i = 0; i < 2; i++)
            {       
                Console.WriteLine("Going");
            }
        }
    }
    }
