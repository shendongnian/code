    public partial class MainWindow : Window
    {
        private LumelauaPikkused lpp;
        private Maesuuusapikkused MSP; //MSP = MaeSuusaPikkused
        public static List<string> LumelauaPikkused = new List<string>();
        public static List<string> MaeSuusapikkused = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            lpp = new LumelauaPikkused();
            MSP = new Maesuuusapikkused();
            VLumelaud.ItemsSource = lpp.Lumelauapikkused;
        }
        // the rest of your code...
    }
