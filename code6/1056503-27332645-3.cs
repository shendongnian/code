    using System.Windows;
    namespace StylesFromResourceExample
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBlock.Inlines.Add(new Run("New Text") { Style = (Style)this.FindResource("RunStyle1") });
        }
    }
    }
