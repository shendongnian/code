    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public static readonly RoutedEvent fooEvent = EventManager.RegisterRoutedEvent("foo", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(MainWindow));
    
        // Provide CLR accessors for the event 
        public event RoutedEventHandler foo
        {
            add { AddHandler(fooEvent, value); }
            remove { RemoveHandler(fooEvent, value); }
        }
    }
