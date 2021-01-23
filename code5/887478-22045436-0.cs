    public class MainWindowViewModel : ViewModelBase
    {
        public PrintQueueViewModel PrintQueue { get; private set; }
    
        public MainWindowViewModel()
        {
            PrintQueue = new PrintQueueViewModel();
            PrintQueue.SelectedPrinterName = "Lexmark T656 PS3";
        }
    }
