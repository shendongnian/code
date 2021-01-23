    public partial class Screen 
    {
        public Screen()
        {
            InitializeComponent();
            ScreenGrid.DataContext = this;
            Items1 = new ObservableCollection<FrameworkElement>();
        }
        public static readonly DependencyProperty Items1Property = 
            DependencyProperty.Register("Items1", typeof(ObservableCollection<FrameworkElement>), typeof(Screen), new PropertyMetadata(null));
        public ObservableCollection<FrameworkElement> Items1
        {
            get { return (ObservableCollection<FrameworkElement>)GetValue(Items1Property); }
            set { SetValue(Items1Property, value); }
        }
    }
