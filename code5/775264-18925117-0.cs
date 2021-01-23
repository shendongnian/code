    <!-- xaml -->
    <Button Click="OnButtonClicked"/>
    // Code behind
    private void OnButtonClicked(object sender, RoutedEventArgs routedEventArgs)
    {
        if(ButtonClickedCommand != null)
        {
            ButtonClickedCommand.Execute(null);
        }
    }
