    class StockModel : INotifyPropertyChanged
    {
        // NOTE: You must implement PropertyChanged notification for these properties...
        public string Symbol { get; set; }
        public decimal Bid { get; set; }
        public decimal Delta { get; set; }  // Change in price over time, +/-
        // Any additional properties you may want here...
    }
