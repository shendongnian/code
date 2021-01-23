    using System.Windows;
    namespace fwWpfDataTemplate
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            TestData testData = new TestData();
            int testIndex = -1;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                testIndex = (testIndex + 1) % testData.Count;
                this.DataContext = testData[testIndex];
            }
        }
    }
