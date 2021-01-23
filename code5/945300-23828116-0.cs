    class ViewModel : INotifyPropertyChanged
    {
        int _customIndex;
        public int CustomIndex
        {
             get 
             {
                 return _customIndex;
             }
             set 
             {
                 _customIndex = value;
                 if(PropertyChanged != null)
                     PropertyChanged(this, new PropertyChangedEventArgs("CustomIndex"));
             }
        }
    }
