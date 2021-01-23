    using System;
    using System.Linq;
    using System.Text;
    using System.Timers;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static readonly Timer MyTimer = new Timer()
            {
                Interval = 60,
            };
            private static void Main(string[] args)
            {
                MyTimer.Elapsed += MyTimerOnElapsed;
            }
            private static void MyTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
            {
                MyTimer.Enabled = false;
                try
                {
                    // Some code here
                }
                finally
                {
                    MyTimer.Enabled = true;
                }
            }
        }
    }
