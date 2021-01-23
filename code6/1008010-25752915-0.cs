    public class FuzzyPickles : INotifyPropertyChanged
    {
        public FuzzyPickles(IPie pieMaker)
        {
            _pieMaker = pieMaker;
        }     
 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _pieName;
        public string PieName
        {
            get
            {
                return _pieName;
            }
            private set 
            {
                _pieName = value;
               OnPropertyChanged()
            }
        }  
        public async Task InitializePieAsync()
        {
            string asyncPieName = string.Empty;
            try
            {
                PieName = await _pieMaker.GetDeliciousPieAsync();
            }
            catch (RottenFruitException e)
            {
                 Debug.Write(e.Message);
            }  
        }
    }
