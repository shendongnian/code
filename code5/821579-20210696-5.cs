    using System.Windows;
    namespace TestWPF
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
