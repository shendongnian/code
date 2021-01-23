    public partial class Chooselogin : Window
    {
        private static bool isFirstTime = true;
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
