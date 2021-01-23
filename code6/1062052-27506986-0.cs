    public class GetRate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string StockName;
        private decimal? VolumeOrdered;
        public decimal? BuyRate;
        public decimal? SellRate;        
        private DateTime? OrderedDate;        
    }
