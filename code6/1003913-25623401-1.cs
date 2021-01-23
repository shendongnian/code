    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HateThisNonMVVMStuff.PreviewLostKeyboardFocus += HateThisNonMVVMStuff_PreviewLostKeyboardFocus;
            HateThisNonMVVMStuff.LostFocus += UIElement_OnLostFocus;
            HateThisNonMVVMStuff.GotFocus += UIElement_OnGotFocus;
        
        }
        void HateThisNonMVVMStuff_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("PrevLostFocus!");
        }
        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Hei! Gained focus");
        }
        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Hei! Lost focus");        
        }
    }
