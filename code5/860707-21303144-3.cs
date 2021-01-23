    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OnDoSomethingExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //Look at e.Parameter   <---!!!This line gives you the value of button content
        }
    }
