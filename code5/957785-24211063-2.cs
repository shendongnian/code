    public class MainWindow
    {
        public MainWindow()
        {
           InitializeComponent();
        
           lvl2 = new Level2();
           DataContext = lvl2;
        }
        
        private void MenuItemMedium_Click(object sender, RoutedEventArgs e)
        {
            lvl2.timer.Start();
        }
    }
