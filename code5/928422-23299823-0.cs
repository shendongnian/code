    private void interface_mouseDown(object sender, MouseButtonEventArgs e)
    {
       if (e.ClickCount == 2)
        MessageBox.Show("Yeah interfac " + ((TextBlock)sender).Text);
    }
