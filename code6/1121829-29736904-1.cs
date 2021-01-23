    private void _swapChainButton_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
		{
			e.Handled = false; //This will pass the event to its parent, which is the _swapChainPanel
		}
	private void _swapChainPanel_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
		{
			game.KeyboardEvent();
		}
