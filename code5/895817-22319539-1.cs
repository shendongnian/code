        public event EventHandler<EventArgs> SelectionChangedEvent;
        public ListBoxInUserControl()
        {
            this.InitializeComponent();
        }
        private void aName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedEvent(sender, new EventArgs());
        }
        private ListBox myVar;
        public ListBox MyProperty
        {
            get { return aName; }
            set { aName = value; }
        }
