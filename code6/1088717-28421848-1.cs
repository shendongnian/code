    partial class MainPage : Page
    {
        private Style TileStyle;
        public MainPage()
        {
            InitializeComponent();
            TileStyle = (Style)this.Resources["TileStyle"];
            // etc.
        }
    }
