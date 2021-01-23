	public CustomCommand RemovePinCommand
	{
		get { return (CustomCommand)GetValue(RemovePinCommandProperty); }
		set { SetValue(RemovePinCommandProperty, value); }
	}
	public static readonly DependencyProperty RemovePinCommandProperty =
		DependencyProperty.Register("RemovePinCommand", 
		typeof(CustomCommand), 
		typeof(PinItem), 
		new UIPropertyMetadata(null));
