    using System.Windows;
    namespace MultipleDataGrid
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
    }
