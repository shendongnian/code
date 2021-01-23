	private void HandleTapImage(object sender, GestureEventArgs e)
	{
		var myPopup = new Popup
		{
			Child = new Image()
			{
				Source = ((Image) sender).Source,
				Stretch = Stretch.UniformToFill,
				Height = Application.Current.Host.Content.ActualHeight,
				Width = Application.Current.Host.Content.ActualWidth
			}
		};
		myPopup.IsOpen = true; 
	}
