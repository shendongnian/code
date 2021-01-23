    using...
    
    namespace WpfMultiDispatcherUpdates
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        private void btnCreateControl_Click(object sender, RoutedEventArgs e)
        {
            TickerControlContainer loclContainer = new TickerControlContainer(this);
        }
    }
    public class TickerControlContainer
    {
        private MainWindow f_Window;
        [DllImport("user32.dll", SetLastError=false, ExactSpelling=false)]
        private static extern IntPtr SetParent(IntPtr hwndChild, IntPtr hwndParent);
        private void CreateControl(HwndSource piclSource)
        {
            TickerControl loclControl = new TickerControl();
            loclControl.InitializeComponent();
            
            Window loclHostWindow = new Window();
            loclHostWindow.WindowStyle = WindowStyle.None;
            loclHostWindow.WindowState = WindowState.Normal;
            loclHostWindow.Left = 0;
            loclHostWindow.Top = 0;
            loclHostWindow.ShowInTaskbar = false;
            loclHostWindow.Content = loclControl;
            loclHostWindow.ShowActivated = true;
            loclControl.Height = 200;
            loclControl.Width = (double)f_Window.Dispatcher.Invoke(new Func<double>(() => { return f_Window.Width; }));
            piclSource.SizeToContent = SizeToContent.WidthAndHeight;
            loclHostWindow.SizeToContent = SizeToContent.WidthAndHeight;
            loclHostWindow.Show();
            SetParent(new WindowInteropHelper(loclHostWindow).Handle, piclSource.Handle);
        }
        private void AddControl(TickerControl piclControl)
        {
            f_Window.Content = new ContentControl() { Content = piclControl };
        }
        public TickerControlContainer(MainWindow piclWindow)
        {
            f_Window = piclWindow;
            ManualResetEvent loclResetEvent = new ManualResetEvent(false);
            Dispatcher loclDispatcher = null;
            Thread th1 = new Thread(new ThreadStart(() =>
                {
                    loclDispatcher = Dispatcher.CurrentDispatcher;
                    loclResetEvent.Set();
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception E)
                    {
                        System.Windows.MessageBox.Show(E.Message);
                    }
                }));
            th1.SetApartmentState(ApartmentState.STA);
            th1.Start();
            loclResetEvent.WaitOne();
            try
            {
                HwndSourceParameters loclSourceParams = new HwndSourceParameters();
                loclSourceParams.WindowStyle = 0x10000000 | 0x40000000;
                loclSourceParams.SetSize((int)piclWindow.Width, 200);
                loclSourceParams.SetPosition(0, 20);
                loclSourceParams.UsesPerPixelOpacity = true;
                loclSourceParams.ParentWindow = new WindowInteropHelper(piclWindow).Handle;
                HwndSource loclSource = new HwndSource(loclSourceParams);
                loclSource.CompositionTarget.BackgroundColor = Colors.Transparent;
                loclDispatcher.BeginInvoke((MethodInvoker)delegate { CreateControl(loclSource); });
            }
            catch (Exception E)
            {
                System.Windows.MessageBox.Show(E.Message);
            }
        }
    }
    }
