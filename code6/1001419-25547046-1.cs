        private static System.Threading.Timer timer;
        private static System.Threading.Timer backupTimer;
        static void Main(string[] args)
        {
            
            timer = new System.Threading.Timer(
             e =>
                {
                //something
            },
            null,
            TimeSpan.Zero,
            TimeSpan.FromMinutes(1));
            backupTimer = new System.Threading.Timer(
             e =>
             {
                 //something
             },
            null,
            TimeSpan.Zero,
            TimeSpan.FromHours(24));
            Console.ReadLine();
                  
        }
