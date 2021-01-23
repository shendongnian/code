    public class AuditLoggableWindow : Window
    {
        public AuditLoggableWindow()
        {
            Closing += OnClosing;
            ContentRendered += OnShown;
        }
        protected void OnClosing(object o, CancelEventArgs e)
        {
            // log that window is closing now
        }
        protected void OnShown(object o, EventArgs e)
        {
            // log that the window has been shown
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AuditLoggableWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
    }
