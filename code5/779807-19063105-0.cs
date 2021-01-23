     public class Data : INotifyPropertyChanged
        {
            private int customerID;
    
            public int CustomerID
            {
                get { return customerID; }
                set { customerID = value; OnPropertyChanged("CustomerID"); }
            }
