    public partial class Chooselogin : Window
    {
        private bool isFirstTime = true;
        public Chooselogin()
        {
            if (isFirstTime)
            {
                new SplashWindow().ShowDialog();
                isFirstTime = false;
            }
            InitializeComponent();
        }
    
        ...
    }
