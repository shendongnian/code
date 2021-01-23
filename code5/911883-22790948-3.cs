    public partial class trainingWindow : Window
        {
            private MainWindow _mainWindow; 
            public trainingWindow(MainWindow mainWindow )
            {
                InitializeComponent();
                _mainWindow = mainWindow;  
            }
    
            private void biuttonBack_Click(object sender, RoutedEventArgs e)
            {
                this.Visibility = Visibility.Hidden; 
                _mainWindow.Visibility = Visibility.Visible;
                
            }
        }
