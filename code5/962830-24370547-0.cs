    <Window ... PreviewMouseDown="Window_PreviewMouseDown">
        <UserControl Name="Control" PreviewMouseDown="UserControl_PreviewMouseDown" ... / >
    </Window>
...
    private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        Control.Background = someNewColourBrush;
    }
    private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        Control.Background = originalColourBrush;
    }
