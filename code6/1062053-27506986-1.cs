    public class GetRate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string StockName;
        private decimal? VolumeOrdered;
        public decimal? BuyRate { get; set; }
        public decimal? SellRate { get; set; }        
        private DateTime? OrderedDate;        
    }
