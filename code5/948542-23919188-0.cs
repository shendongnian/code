    namespace ThrowAway
    {
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoCrazyLoop();
        }
        public void DoCrazyLoop()
        {
            DateTime myBirthday = new DateTime(1984, 01, 19);
            bool breakLoop = false;
            Timer t = new Timer(o =>
            {
                breakLoop = true;
            }, null, 10000, 100);
            while (breakLoop == false)
            {
                TimeSpan daysAlive = DateTime.Now.Subtract(myBirthday);
                MyTextBlock.Text = daysAlive.TotalDays.ToString();
            }
        }
     }
    }
