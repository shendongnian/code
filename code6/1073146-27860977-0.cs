    public abstract class BaseViewModel : INotifyPropertyChanged
        {
            protected bool ChangeAndNotify<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
            {
                if (!EqualityComparer<T>.Default.Equals(property, value))
                {
                    property = value;
                    NotifyPropertyChanged(propertyName);
                    return true;
                }
    
    
                return false;
            }
    
    
            protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
