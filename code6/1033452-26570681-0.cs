    Button.Click += this.Button_Click;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            button.IsEnabled = false;
            button.Content = X;
         }
    }
