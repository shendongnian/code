    private void  MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
         TextBox textBox = (TextBox)sender;
        textBox.IsReadOnly = false;
        textBox.Background = new SolidColorBrush(Colors.White);
        textBox.Foreground = new SolidColorBrush(Colors.Black);
    }
