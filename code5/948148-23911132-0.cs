    public partial class MainWindow : Window
    {
        private static Task _task;
        private static TaskScheduler _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private static CancellationToken _cancelToken = new CancellationToken();
    
        public static Task ProTask {
            get { return _task; }
        }
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void ProcessEventHandler(object s, ProcessEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal,
                    (Action)(() => { _processText.Text = e.State; }));
        }
    
        private void StartProcess()
        {
            var outputText = new OutputText();
            outputText.processEventArgsHandler += ProcessEventHandler;
            outputText.SimulateProcessOutput();
        }
    
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(StartProcess);
        }
    }
