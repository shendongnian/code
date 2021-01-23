    public partial class  Settings: Window
    {
        Object _object;
        public Settings(Object object)
        {
            _object = object
            InitializeComponent();
        }
        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // get text in object
            String name = _object.Text;
        }
