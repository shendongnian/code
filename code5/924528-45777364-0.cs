    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(params string[] props)
        {
            foreach (var prop in props)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName]string prop = "")
        {
            if (oldValue.Equals(newValue))
                return;
            oldValue = newValue;
            OnPropertyChanged(prop);
        }
    }
