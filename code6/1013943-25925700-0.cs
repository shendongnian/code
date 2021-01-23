        private void startButton_Click(object sender, RoutedEventArgs e)
            {
                Random rand = new Random();
                int ranMin = rand.Next(1,24);
                int ranSec = rand.Next(0, 59);
        
        
                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, ranMin, ranSec);
                dispatcherTimer.Start();
        
                // New timer
                System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
                dispatcherTimer2.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer2.Start();
        
                min.Content = ranMin;
                sec.Content = ranSec;
        
                openP();
        
            }
    
            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                //code for timer in here
            }
    
            private void dispatcherTimer2_Tick(object sender, EventArgs e)
            {
               //code for timer2 in here
            }
