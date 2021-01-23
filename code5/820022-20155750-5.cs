    public partial class MainWindow : Window
    {
        private int m_fontSize = 20;
        public int MyFontSize
        {
            get { return m_fontSize; }
            set
            {
                if (m_fontSize != value)
                {
                    m_fontSize = (value > 0) ? value : 10;
                }
            }
        }
        public string MyToolTip
        {
            get { return "hello world"; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
