    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        if (txtdata.Text != "")
        {
            MyPopup.IsOpen = false;
            LayoutRoot.Opacity = 1.0;
            MessageBox.Show(txtdata.Text);
        }
    }
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = false;
        LayoutRoot.Opacity = 1.0;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = true;
        LayoutRoot.Opacity = 0.5;
    }
