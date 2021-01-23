    public partial class SettingsWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OK_OnClick(object sender, RoutedEventArgs e)
        {
            Building.Code = "BS Code;
            OnPropertyChanged("CurrentCode");
        }
        ...
    }
