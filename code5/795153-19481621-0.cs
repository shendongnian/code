    public class Item : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
    
            decimal centimeters;
            decimal inches;
    
            public decimal Centimeters
            {
                get { return centimeters; }
                set
                {
                    centimeters = value;
                    NotifyPropertyChanged("Centimeters");
                }
            }
    
            public decimal Inches
            {
                get { return inches; }
                set
                {
                    inches = value;
                    NotifyPropertyChanged("Inches");
                }
            }
    
        }
