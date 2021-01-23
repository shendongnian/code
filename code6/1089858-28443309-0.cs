    class Item
    {
        private List<Stat> stat;
        public List<Stat> Stats
        {
            get { return stat; }
            set { stat = value; }
        }
        public ObservableCollection<Stat> ObservableStats
        {
            get { return new ObservableCollection<Stat>(stat); }            
        }
        
    }
