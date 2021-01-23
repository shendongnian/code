        public ValidationModel()
        {
        }
        private string _validationName;
        private string _validationDescription;
        private int _validationId;
        public string validationName
        {
            get { return _validationName; }
            set { _validationName = value; NotifyPropertyChanged("ValidationName"); }
        }
        public string validationDescription
        {
            get { return _validationDescription; }
            set { _validationDescription = value; NotifyPropertyChanged("ValidationDescription"); }
        }
        public int validationId
        {
            get { return _validationId; }
            set { _validationId = value;}
        }
        public ValidationModel GetDeepCopy()
        {
            var model = new ValidationModel();
            model.validationId = validationId;
            model.validationName = validationName;
            model.validationDescription = validationDescription;
            return model;
        
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
