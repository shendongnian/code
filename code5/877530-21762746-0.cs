        private System.Threading.Timer _myTimer;
        private AutoResetEvent _myEvent = new AutoResetEvent(false);
        private void DoIt()
        {
            _myTimer = new Timer(MyTimerCallback, null, 1000, 1000);
            Console.WriteLine("Press Enter when done");
            Console.ReadLine();
            _myTimer.Dispose();
        }
        private void MyTimerCallback(object state)
        {
            _myEvent.Set();
            Console.WriteLine("tick");
        }
