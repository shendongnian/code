    private void OnButtonClick(object sender, RoutedEventArgs e)
    {            
                System.Windows.Media.Brush br = ((Button)sender).Background;
                ((Button)sender).Background = System.Windows.Media.Brushes.Red;
    
                Mouse.OverrideCursor = Cursors.Wait;
                // Run function in a new thread.
                Task.Factory.StartNew(() =>
                {
                    Function(); // Long running function.
                })
                .ContinueWith((result) =>
                    {
                        // Runs when Function is complete...
                        Mouse.OverrideCursor = Cursors.Arrow;
                        ((Button)sender).Background = br;       
                    }); 
                           
    }
