    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            People.Loaded += People_Loaded;
        }
        void People_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 0; i < People.Items.Count; i++)
            {
                var container = People.ItemContainerGenerator.ContainerFromIndex(i);
                container.SetValue(SlideInEffect.LineIndexProperty, i);
            }
        }
    }
