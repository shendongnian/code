    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private members
        private List<TestClass> _tests;
        private TestClass _gridSelectedItem;
        private ICommand _changeSelectedItemCommand;
        private int _selectedGridIndex;
        #endregion
        #region Constructor
        
        public MainWindowViewModel()
        {
            Tests = new List<TestClass>();
            for (int i = 0; i < 25; i++)
            {
                TestClass testClass= new TestClass {Name = "Name " + i, Title = "Title" + i};
                Tests.Add(testClass);
            }
        }
        #endregion
        #region Public properties
        public List<TestClass> Tests
        {
            get { return _tests; }
            set
            {
                _tests = value;
                OnPropertyChanged("Tests");
            }
        }
        public TestClass GridSelectedItem
        {
            get { return _gridSelectedItem; }
            set
            {
                _gridSelectedItem = value;
                OnPropertyChanged("GridSelectedItem");
            }
        }
        public int SelectedGridIndex
        {
            get { return _selectedGridIndex; }
            set
            {
                _selectedGridIndex = value;
                OnPropertyChanged("SelectedGridIndex");
            }
        }
        #endregion
        public ICommand ChangeSelectedItemCommand
        {
            get { return _changeSelectedItemCommand ?? (_changeSelectedItemCommand = new  SimpleCommand(p => ChangeSelectedGridItem())); }
        }
        private void ChangeSelectedGridItem()
        {
            SelectedGridIndex++;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
