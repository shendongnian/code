    internal class ItemImage : IItem 
    {   
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public event EventHandler Completed;
        private DispatcherTimer _dt = new DispatcherTimer();
        // constructor
        public ItemImage()
        {
            _dt.Tick += (s, e) =>
            {
                _dt.Stop();
                Completed(this, new EventArgs());
            };
        }
        public void Show()
        {
            _dt.Interval = this.Duration;
            _dt.Start();
        }
    }
