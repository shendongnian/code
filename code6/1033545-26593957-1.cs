    class ViewModelSample : INotifyPropertyChanged  // uses System.ComponentModel
    {
        private List<ModelSample> models = new List<ModelSample>();
        public List<ModelSample> Models 
        { 
            get { return models; }
            set
            {
                models = value;
                NotifyPropertyChanged("Models");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }   
    }
