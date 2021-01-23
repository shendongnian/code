        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
                     for (var i = 1; i <= 10; i++)
                     {
                         penSizes.Items.Add(i);
                     }
                
                     penSizes.SelectedIndex = 0;
                     //set slider's value here
                     penSizeSlider.Value=1;
                     //...rest code
        }
