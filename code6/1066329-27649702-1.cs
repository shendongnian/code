        private GridLength _leftGridWidth;
        private GridLength _rightGridWidth;
        private readonly GridLength _defaultRightGridWidth = new GridLength(0, GridUnitType.Pixel);
        public MainWindowViewModel()
        {
            ShowRightGridCommand = new DelegateCommand(SwitchRightGridWidth);
            LeftGridWidth = new GridLength(7, GridUnitType.Star);
            RightGridWidth = _defaultRightGridWidth;
        }
        private void SwitchRightGridWidth()
        {
            RightGridWidth = RightGridWidth == _defaultRightGridWidth ? new GridLength(3, GridUnitType.Star) : _defaultRightGridWidth;
        }
        public GridLength LeftGridWidth
        {
            get { return _leftGridWidth; }
            set { _leftGridWidth = value; OnPropertyChanged();}
        }
        public GridLength RightGridWidth
        {
            get { return _rightGridWidth; }
            set { _rightGridWidth = value; OnPropertyChanged();}
        }
        public ICommand ShowRightGridCommand { get; set; }
