    public class MyClass : INotifyPropertyChanged
    {
        private Random random;
        private int m_MyInt;
        public int MyInt
        {
            get
            {
                return m_MyInt;
            }
            set
            {
                if ( m_MyInt == value )
                {
                   return;
                }
                m_MyInt = value;
                NotifyPropertyChanged();
            }
        }
        private static MyClass m_Instance;
        public static MyClass Instance
        {
            get
            {
                if ( m_Instance == null )
                {
                    m_Instance = new MyClass();
                }
                return m_Instance;
             }
        }
        private MyClass()
        {
            random = new Random();
            m_MyInt = random.Next( 0, 100 );
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        private void timer_Elapsed( object sender, ElapsedEventArgs e )
        {
            MyInt = random.Next( 0, 100 );
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
