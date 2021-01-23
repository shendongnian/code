        private static readonly Properties<MainWindowViewModel> _properties = new Properties<MainWindowViewModel>();
        public static Property TextProperty = _properties.Create(_ => _.Text);
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value, TextProperty); }
        }
