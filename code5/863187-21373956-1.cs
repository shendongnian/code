    public partial class CustomMenu : UserControl
    {
        public CustomMenu()
        {
            InitializeComponent();
        }
        public ObservableCollection<CustomMenuItem> Items
        {
            get { return (ObservableCollection<CustomMenuItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", 
            typeof(ObservableCollection<CustomMenuItem>), 
            typeof(CustomMenu), 
            new PropertyMetadata(new ObservableCollection<CustomMenuItem>()));
    }
