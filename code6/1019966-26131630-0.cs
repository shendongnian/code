    class Program
    {
        static void Main(string[] args)
        {
            var helper = new Looper(5000, YourMethod_RefreshThread);
            helper.Start();
        }
        private static void YourMethod_RefreshThread()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
    public class Looper
    {
        private readonly Action _callback;
        private readonly int _interval;
        public Looper(int interval, Action callback)
        {
            if(interval <=0)
            {
                throw new ArgumentOutOfRangeException("interval");
            }
            if(callback == null)
            {
                throw new ArgumentNullException("callback");
            }
            _interval = interval;
            _callback = callback;
        }
        private void Work()
        {
            var next = Environment.TickCount;
            do
            {
                if (Environment.TickCount >= next)
                {
                    _callback();
                    next = Environment.TickCount + _interval;
                }
                Thread.Sleep(_interval);
            } while (IsRunning);
        }
        public void Start()
        {
            if (IsRunning)
            {
                return;
            }
            var thread = new Thread(Work);
            thread.Start();
            IsRunning = true;
        }
        public void Stop()
        {
            this.IsRunning = false;
        }
        public bool IsRunning { get; private set; }
