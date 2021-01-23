    private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        MessageBox.Show("MouseDown!"); // now when you click, it will not be displayed
    }
