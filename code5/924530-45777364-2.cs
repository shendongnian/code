    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(params string[] props)
        {
            foreach (var prop in props)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public bool SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName]string prop = "")
        {
            if (oldValue == null && newValue == null)
                return false;
            if (oldValue != null && oldValue.Equals(newValue))
                return false;
            oldValue = newValue;
            OnPropertyChanged(prop);
            return true;
        }
    }
