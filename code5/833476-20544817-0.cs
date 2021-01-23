    ...
    var myProcessor = new SerialProcessor(DataSource.DataView.GetEnumerator())
    myProcessor.Start();
    ...
    public class SerialProcessor
    {
        private IEnumerable items;
        private DispatcherTimer clock;
        
        public SerialProcessor(IEnumerable items)
        {
            this.items = items;
            this.clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(8);
            clock.Tick += (o, e) =>
            {
                clock.Stop();
                if (!this.items.MoveNext()) return;
                var item = this.items.Current;
                open(0, item); // <-- This is where you do whatever processing you want to do. If you want to be REALLY slick, pass it into this class as a Func<> or Action<>
                // Resume processing
                clock.Start();
            };
        }
        public void Start()
        {
            clock.Start();
        }
        // Add Cancel method to stop the clock, status events, etc.
    }
