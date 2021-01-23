      public class Model_Ricerca_Dati_Viaggio:INotifyPropertyChanged
    {
        private string _numOrd ;
        public string NumOrd  
        {
            get
            {
                return _numOrd;
            }
            set
            {
                if (_numOrd == value)
                {
                    return;
                }
                _numOrd = value;
                OnPropertyChanged("NumOrd");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 
