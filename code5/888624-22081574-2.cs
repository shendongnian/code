    public class UnitSource :INotifyPropertyChanged
    {
        public IEnumerable Units
        {
            get { return new[] { "Test Unit", "Alternate Unit" }; }
        }
        string _selectedComboItem1;
        public string SelectedComboItem1
        {
            get
            {
                return _selectedComboItem1;
            }
            set
            {
                if (_selectedComboItem1 == value)
                    return;
                _selectedComboItem1 = value;
                OnPropertyChanged();
            }
        }
        string _selectedComboItem2;
        public string SelectedComboItem2
        {
            get
            {
                return _selectedComboItem2;
            }
            set
            {
                if (_selectedComboItem2 == value)
                    return;
                _selectedComboItem2 = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
