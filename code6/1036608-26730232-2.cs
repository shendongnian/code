        public static DependencyProperty NamesProperty = DependencyProperty.Register(
            "Names",
            typeof(ObservableCollection<People>),
            typeof(MainWindow));
        public ObservableCollection<People> Names
        {
            get { return (ObservableCollection)GetValue(NamesProperty); }
            private set { SetValue(NamesProperty, value); }
        }
