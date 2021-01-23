    class Level2
    {
        public event Action<int> CounterUpdated;
    
        ...
        public void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (CounterUpdated != null)
               CounterUpdated(counter);
        }
    }
    
    public class MainWindow
    {
        public MainWindow()
        {
           InitializeComponent();
        
           lvl2 = new Level2();
           lvl2.CounterUpdated += UpdateCounterText;
        }
        
        private void MenuItemMedium_Click(object sender, RoutedEventArgs e)
        {
           lvl2.timer.Start();
        }
        
        private void UpdateCounterText(int newCounterValue)
        {
            TbTimer.Content = newCounterValue.ToString();
        }
    }
