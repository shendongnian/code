    public class MainViewModel : ViewModelBase
    {
        private string _selectedItem;
    
        public List<string> Items { get; private set; }
    
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem) return;
                var previousItem = _selectedItem;
                _selectedItem = value;
                var isInvalid = value == "Bus"; // replace w/ your messenger code
                if (isInvalid)
                {
                    Application.Current.Dispatcher.BeginInvoke(
                        new Action(() => ResetSelectedItem(previousItem)),
                        DispatcherPriority.ContextIdle,
                        null);
                    return;
                }
                RaisePropertyChanged();
            }
        }
    
        public MainViewModel()
        {
            Items = new[] { "Car", "Bus", "Train", "Airplane" }.ToList();
            _selectedItem = "Airplane";
        }
    
        private void ResetSelectedItem(string previousItem)
        {
            _selectedItem = previousItem;
            RaisePropertyChanged(() => SelectedItem);
        }
    }
