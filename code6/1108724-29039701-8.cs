    public class ServerMenuCommands
    {
        public static event EventHandler ServerStartedChanged;
        private static Boolean _ServerStarted;
        public static Boolean ServerStarted
        {
            get
            { 
                return _ServerStarted; 
            }
            set
            {
                if (value != _ServerStarted)
                {
                    _ServerStarted = value;
                    if (ServerStartedChanged != null)
                        ServerStartedChanged(typeof(ServerMenuCommands), EventArgs.Empty);
                }
            }
        }
        public static readonly RoutedUICommand OpenPuttyDisplayCommand = new RoutedUICommand("Open Putty Display", "PUTTY_DISPLAY", typeof(ServerMenuCommands));
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ServerMenuCommands.ServerStarted = !ServerMenuCommands.ServerStarted;
        }
    }
