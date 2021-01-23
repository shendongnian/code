    public class TickerData
    {
        private event Action tickerChanged;
        private string _symbol;
        public string symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                tickerChanged();
            }
        }
        private string _exchange;
        public string exchange
        {
            get
            {
                return _exchange;
            }
            set
            {
                _exchange= value;
                tickerChanged();
            }
        }
        // ... continue the pattern ...
        
        public DateTime lastUpdate { get; set; }
        public TickerData()
        {
            // register an event handler that
            // updates the lastUpdate property
            tickerChanged += () => lastUpdate = DateTime.Now;
        }
    }
