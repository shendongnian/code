    using System;
    using System.Threading;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            void test()
            {
                using (var inactivityDetector = new InactivityDetector(TimeSpan.FromSeconds(2), inactivityDetected))
                {
                    for (int loop = 0; loop < 3; ++loop)
                    {
                        Console.WriteLine("Keeping busy once a second for 5 seconds.");
                        for (int i = 0; i < 5; ++i)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Registering activity");
                            inactivityDetector.RegisterActivity();
                        }
                        Console.WriteLine("Entering 3 second inactivity");
                        Thread.Sleep(3000);
                        inactivityDetector.RegisterActivity();
                    }
                }
            }
            static void inactivityDetected()
            {
                Console.WriteLine("Inactivity detected.");
            }
            static void Main(string[] args)
            {
                new Program().test();
            }
        }
        public sealed class InactivityDetector: IDisposable
        {
            public InactivityDetector(TimeSpan inactivityThreshold, Action onInactivity)
            {
                _inactivityThreshold = inactivityThreshold;
                _onInactivity        = onInactivity;
                _timer               = new Timer(timerCallback, null, (int)inactivityThreshold.TotalMilliseconds, -1);
            }
            public void RegisterActivity()
            {
                _timer.Change(-1, -1);
                _timer.Change((int)_inactivityThreshold.TotalMilliseconds, -1);
            }
            private void timerCallback(object state)
            {
                _timer.Change(-1, -1);
                _onInactivity();
            }
            public void Dispose()
            {
                _timer.Dispose();
            }
            private readonly TimeSpan _inactivityThreshold;
            private readonly Action _onInactivity;
            private readonly Timer _timer;
        }
    }
