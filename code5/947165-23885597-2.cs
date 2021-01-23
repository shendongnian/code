    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Random random;
        private int m_Value1;
        public int Value1
        {
            get
            {
                return m_Value1;
            }
            set
            {
                if ( m_Value1 == value )
                {
                   return;
                }
                m_Value1 = value;
                NotifyPropertyChanged();
            }
        }
        private int m_Value2;
        public int Value2
        {
            get
            {
                return m_Value2;
            }
            set
            {
                if ( m_Value2 == value )
                {
                    return;
                }
                m_Value2 = value;
                NotifyPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            random = new Random();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed( object sender, ElapsedEventArgs e )
        {
            Value1 = random.Next( 0, 2 );
            Value2 = random.Next( 0, 2 );
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
        #endregion
    }
