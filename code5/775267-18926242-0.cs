    public event RoutedEventHandler ButtonClicked;
        private void MyButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(sender, e);
            }
        }
