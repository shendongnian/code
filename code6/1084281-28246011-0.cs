    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            const bool generate = true;
            NewBookingTimer(generate);
            Console.WriteLine("Running...");
            Console.ReadLine();
        }
        public static void NewBookingTimer(bool generate)
        {
            if (!generate) return;
            var newBookingTimer = new Timer();
            newBookingTimer.Elapsed += (sender, e) =>
            {
                MethodA();
                MethodB();
            };
            var random = new Random();
            int randomNumber = random.Next(0, 500);
            newBookingTimer.Interval = randomNumber;
            newBookingTimer.Enabled = true;
        }
        public static void MethodA()
        {
            Console.WriteLine("in method A");
        }
        public static void MethodB()
        {
            Console.WriteLine("in method B");
        }
    }
