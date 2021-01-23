    public class MyViewModel
    {
        private ObservableCollection<MyClass> _myCollection;
        public ObservableCollection<MyClass> MyCollection
        {
            get { return _myCollection; }
            set
            {
                _myCollection = value;
                RaisePropertyChanged("MyCollection");
            }
        }
        //...
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand== null)
                    _refreshCommand= new RelayCommand<MyClass>(p => Refresh(p));
                return _refreshCommand;
            }
        }
        public void Refresh(MyClass parameter)
        {
            if (null == parameter)
                return;
            parameter.ExecuteMyCommand();
            // Do work to refresh MyCollection to it's "live" state
        }
    }
