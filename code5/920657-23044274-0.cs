    using System;
    
    class Program {
        static System.Timers.Timer timer;
        static void Main(string[] args) {
            timer = new System.Timers.Timer();
            timer.AutoReset = false;
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Console.ReadLine();
        }
    
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            timer.Interval = 1000;
            Console.WriteLine("Tick");
        }
    }
