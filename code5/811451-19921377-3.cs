    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        themeList = new List<Theme>();
        themeList.Add(new Theme() { Image = new BitmapImage(new Uri("/Assets/Themes/Indigo.png", UriKind.Relative)), Name = "indigo", Color = Color.FromArgb(255, 106, 0, 255) });
        themeList.Add(new Theme() { Image = new BitmapImage(new Uri("/Assets/Themes/Cyan.png", UriKind.Relative)), Name = "cyan", Color = Color.FromArgb(255, 27, 161, 226) });
        themeList.Add(new Theme() { Image = new BitmapImage(new Uri("/Assets/Themes/Cobalt.png", UriKind.Relative)), Name = "cobalt", Color = Color.FromArgb(255, 0, 80, 239) });
		var viewModel = new PageViewModel();
		viewModel.Themes = themeList;
        DataContext = viewModel;
    }
	
