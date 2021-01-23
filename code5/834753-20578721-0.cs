    public class Height:INotifyPropertyChanged
    {
        GridLength _gridheight = new GridLength(200);
        public GridLength GridHeight
                {
                        get{
                                return _gridheight;
                           }
                        set{
                                if(_gridheight==value)
                                   return;
                                _gridheight=value;
                                NotifyPropertyChanged("GridHeight")
                            }
  
             }
      public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
