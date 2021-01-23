    class MainViewModel
    {
        ObservableCollection<object> _children;
        public MainViewModel()
        {
            _children = new ObservableCollection<object>();
            _children.Add(new Tab1ViewModel());
            _children.Add(new Tab2ViewModel());
        }
        public ObservableCollection<object> Children { get { return _children; } }
    }
