    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Retrieve your selected printer here; in this case, I just set it directly
            var selectedPrinter = "Lexmark T656 PS3";
            var viewModel = (PrintQueueViewModel)PrintQueue.DataContext;
            viewModel.SelectedPrinterName = selectedPrinter;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            var viewModel = (PrintQueueViewModel)PrintQueue.DataContext;
            var selectedPrinterName = viewModel.SelectedPrinterName;
            // Save the name of the selected printer here
            base.OnClosing(e);
        }
    }
