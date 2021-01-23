    private void UserControl_Hold(object sender, System.Windows.Input.GestureEventArgs e)
    {
        myPopup.IsOpen = true;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        myPopup.IsOpen = false;
    }
