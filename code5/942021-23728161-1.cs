    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
            // set color here
            MyBackgroundColor = Colors.Red;
        }
        private Color _myBackgroundColor;
        public Color MyBackgroundColor
        {
            [DebuggerStepThrough]
            get { return _myBackgroundColor; }
            [DebuggerStepThrough]
            set
            {
                if (value != _myBackgroundColor)
                {
                    _myBackgroundColor = value;
                    OnPropertyChanged("MyBackgroundColor");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
