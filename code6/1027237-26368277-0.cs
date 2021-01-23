    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            statusText.Text = "Running";
            statusText.Text = await _ComputeText(true);
            statusText.Text = await _ComputeText(false);
        }
        private static async Task<string> _ComputeText(bool initialTask)
        {
            string result = await Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    return initialTask ? "Task is done!" : "Idle";
                });
            return result;
        }
    }
