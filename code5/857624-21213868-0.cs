    class TreeNodeVm : NotificationObject
    {
        private bool _isSelected = false;
        public bool IsSelected 
        {
            get { return _isSelected; }
            set 
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }
        public ObservableCollection<TreeNodeVm> Children { get; private set; }
        public string Header { get; set; }
        public TreeNodeVm()
        {
            this.Children = new ObservableCollection<TreeNodeVm();
        }
    }
