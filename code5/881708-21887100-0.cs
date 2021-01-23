    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow(MainWindow otherWindow) : this()
            {
                if (otherWindow != null)
                {
                    otherWindow.Close();
                }
            }
            public MainWindow()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                MainWindow mWin = new MainWindow(this);
                mWin.ShowDialog();
            }
        }
    }
