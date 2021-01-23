    public sealed partial class MainPage : Page
    {
        public List<string> MapProviders { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            MapProviders = new List<string>
            {
                "Unison Maps",
                "Google Maps",
                "Bing Maps",
                "OpenStreetMap",
                "OpenCycleMap",
                "OCM Transport",
                "OCM Landscape",
                "MapQuest OSM"
            };
        }
    }
