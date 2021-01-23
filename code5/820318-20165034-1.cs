    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyClass mc = new MyClass();
            Stopwatch sw = new Stopwatch();
            Settings set = new Settings();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                mc.DoStuff();
            }
            sw.Stop();
            tb1.Text = sw.ElapsedTicks.ToString();
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                mc.DoStuff(set);
            }
            sw.Stop();
            tb2.Text = sw.ElapsedTicks.ToString();
        }
    }
    class MyClass
    {
        Settings currentSettings = new Settings();
        public void DoStuff()
        {
            int test = 0;
            for(int k = 0; k < 10 ; k++)
            {
                test += currentSettings.i + currentSettings.j;
            }
            
        }
        public void DoStuff(Settings settings)
        {
            int test = 0;
            for (int k = 0; k < 10; k++)
            {
                test += settings.i + settings.j;
            }
        }
    }
    class Settings
    {
        public int i = 1, j = 2;
    }
