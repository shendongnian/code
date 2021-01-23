    public class MainViewModel : ViewModelBase
    {        
        private bool leftWidgetEnabled;
        public bool LeftWidgetEnabled
        {
            get { return leftWidgetEnabled; }
            set { SetField(ref leftWidgetEnabled, value, "LeftWidgetEnabled"); }
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
