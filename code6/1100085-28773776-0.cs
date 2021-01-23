    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Accept)
                HandleAll();
        }
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            HandleAll();
        }
    private void HandleAll()
        {
            //Hit breakpoint here
        }
