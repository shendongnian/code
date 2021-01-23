    public partial class Tilføj_Øvelse : Window
    {
        MainWindow mw;
    
        public Tilføj_Øvelse(Window window)
        {
            InitializeComponent();
            mw = window;
        }
    
        private void btnTilføj_Click(object sender, RoutedEventArgs e)
        {
            mw.AddRow("Bænkpres", "80", "3", "10", "50");
            Close();
        }
    
        private void btnAnuller_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
