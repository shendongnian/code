        private string _validationName;
  
        public string validationName
        {
            get { return _validationName; }
            set { _validationName = value; NotifyPropertyChanged("ValidationName"); }
        }
       
        public ValidationModel GetDeepCopy()
        {
            var model = new ValidationModel();
           
            model.validationName = validationName;
           
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
