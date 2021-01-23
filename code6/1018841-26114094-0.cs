    public class FirstViewModel : MvxViewModel
    {
        private int _currentDessertIndex;
        public int CurrentDessertIndex 
        {   
            get { return _currentDessertIndex; }
            set { 
                _currentDessertIndex = value; 
                _currentDessert = _desserts[value]; 
                RaisePropertyChanged(() => CurrentDessertIndex); 
                RaisePropertyChanged(() => CurrentDessert); 
            }
        }
    
        private Dessert _currentDessert;
        public Dessert CurrentDessert 
        {   
            get { return _currentDessert; }
            set { 
                _currentDessert = value; 
                _currentDessertIndex = _desserts.IndexOf(_currentDessert);
                RaisePropertyChanged(() => CurrentDessertIndex); 
                RaisePropertyChanged(() => CurrentDessert); 
            }
        }
    }
