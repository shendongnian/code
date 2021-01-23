        private int counter = 0;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MicroTimerTest();
        }
        private void MicroTimerTest()
        {
    
            MicroLibrary.MicroTimer microTimer = new MicroLibrary.MicroTimer();
            microTimer.MicroTimerElapsed +=
                new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
            microTimer.Interval = 1000; // Call micro timer every 1000µs (1ms)
            microTimer.Enabled = true; // Start timer
            System.Threading.Thread.Sleep(2000); //do smth 2 seconds
            microTimer.Enabled = false; // Stop timer (executes asynchronously)
            Console.ReadLine();
        }
        private void OnTimedEvent(object sender,
                                MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            // Do something every ms
            Console.WriteLine(++counter);
        }
    }
}
