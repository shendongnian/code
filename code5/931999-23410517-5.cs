    public class RandomNumber
        {
            static Random R = new Random();
            ManualResetEvent evt;
    
            public ManualResetEvent Event
            {
                get
                {
                    return evt;
                }
                set
                {
                    evt = value;
                }
            }
    
            public void Show()
            {
                while (true)
                {
                    evt.WaitOne();
                    lock (ControlEvent.Locker)
                    {
                       Console.WriteLine("Random number: " + R.Next(1000));
                    }
                    Thread.Sleep(100);
                }
            }
        }
