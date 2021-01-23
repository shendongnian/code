    class Cards
    {
        private ObservableCollection<Card> _CardCollection = new ObservableCollection<Card>();
        
        public  ObservableCollection<Card> CardCollection
        {
            get
            { 
                return _CardCollection;
            }
            set
            {
                  _CardCollection=value;
                  OnPropertyChanged("CardCollection");  //Implement property changed event  
            }
        }
    }
