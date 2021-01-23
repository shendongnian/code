    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Win1 OP= new Win1();
        var host = new Window();
        host.Content = OP;
        host.Show();
    }
