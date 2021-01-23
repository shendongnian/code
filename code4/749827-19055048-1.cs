    using System.Windows;
    
    namespace GridRowHidingSample
    {
        public partial class MainWindow : Window
        {
            private MainWindowViewModel _viewModel;
            public MainWindow()
            {
                InitializeComponent();
    
                _viewModel = new MainWindowViewModel(TopRow, BottomRow);
                DataContext = _viewModel;
            }
        }
    }
