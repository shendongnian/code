    public partial class  Settings: Window
    {
        MyClass _object;
    
        public Settings(Object object)
        {
            _object = object
            InitializeComponent();
        }
    
        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // get text in object
            var name = _object.Text;
        }
    }
