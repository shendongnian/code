    using System.Windows;
    using System.Windows.Controls;
    
    public sealed partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.CreateAndAddTabItem("MainWindow");
        }
    
        // This manages the creation and addition of new tab items to the tab control
        // It also sets up the subscription to the event in the uscEstimate control
        private void CreateAndAddTabItem(string header)
        {
            var tab = new TabItem { Header = header };
            tbcMain.Items.Add(tab);
            var uscEstimate = new uscEstimate();
            uscEstimate.AddNewItemEventHandler += AddNewItemEventHandler;
            tab.Content = uscEstimate;
            tab.Focus();
        }
    
        // This handles the raised AddNewItemEventHandler notifications sent from uscEstimate
        private void AddNewItemEventHandler(object sender, UserControl userControl)
        {
            this.CreateAndAddTabItem("uscEstimate");
        }
    }
