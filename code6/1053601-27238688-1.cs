        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            Uri oneX = new Uri("pan.xaml", UriKind.Relative);
            if (NumberBox.SelectedItem == TwoBoxItem)
            {
                comboFrame.Dispatcher.Invoke(delegate
                {
                    comboFrame.Source = oneX;
                }
                );
            }
