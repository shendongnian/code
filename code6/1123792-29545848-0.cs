     private void button2_Click(object sender, RoutedEventArgs e)
        {
            Download d = new Download();
            var task = Task.Factory.StartNew(() =>
            {               
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(30);
                    System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
                    {
                        d.progressBar1.Value = i;
                    }));  
                }               
            });            
            d.progressBar1.Minimum = 1;
            d.progressBar1.Maximum = 100;
            d.Show(); 
        }
