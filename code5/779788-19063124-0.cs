       public class Data : INotifyPropertyChanged
            {
                private int customerID;
        
                public int CustomerID
                {
                    get { return customerID; }
                    set { customerID = value; OnPropertyChanged("CustomerID"); }
                }
          public event PropertyChangedEventHandler PropertyChanged;
        
                public void OnPropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        var e = new PropertyChangedEventArgs(propertyName);
                        handler(this, e);
                    }
                }
