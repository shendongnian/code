    // to change the appearance of the top navigation bar title
	UITextAttributes attributes = new UITextAttributes();
	    // set custom text color
	attributes.TextColor = UIColor.FromRGB(255, 122, 122);
	attributes.Font = UIFont.BoldSystemFontOfSize(20);
	attributes.TextShadowColor = UIColor.FromRGBA(255, 255, 255, 128);
	attributes.TextShadowOffset = new UIOffset(2, -2);
	// to add buttons to navigation bar
	UIBarButtonItem[] items = new UIBarButtonItem[]
	{
		new UIBarButtonItem(
			NSBundle.MainBundle.LocalizedString("Tilbage", null),
			UIBarButtonItemStyle.Bordered,
			delegate(object sender, EventArgs e) {
			    // do whatever you need
			Console.WriteLine("Custom button clicked!");
		})
	};
	NavigationController.NavigationBar.TintColor = UIColor.FromRGBA(255, 196, 196, 255);
	NavigationController.NavigationBar.TopItem.Title = NSBundle.MainBundle.LocalizedString("LocalizedHeader", null);
	// change appearance
	NavigationController.NavigationBar.SetTitleTextAttributes(attributes);
	// add buttons
	NavigationItem.LeftBarButtonItems = items;
