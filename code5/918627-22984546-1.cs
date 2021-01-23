    private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            { 
              Dispatcher.BeginInvoke(() =>
                    {
                        string value = string.Format("{0}",  e.NewValue);
                        sliderValue.Text = value;
                    }); 
               
            }
