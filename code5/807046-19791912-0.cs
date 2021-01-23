    class ViewModel : INotifyPropertyChanged
    {
      private bool leftWidgetEnabled;
      public bool LeftWidgetEnabled
      {
         get 
          { 
            return leftWidgetEnabled;
          }
          set 
          { 
              leftWidgetEnabled=value
             OnPropertyChanged("LeftWidgetEnabled"); 
          }
       }
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
