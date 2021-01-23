    ApplicationBar appBar = new ApplicationBar();
    appBar.Mode = ApplicationBarMode.Minimized;
    appBar.IsMenuEnabled = true;
    appBar.IsVisible = true;
    appBar.BackgroundColor = Color.FromArgb(120, 0,229,249)
    
    ApplicationBarIconButton button = new ApplicationBarIconButton();
    button.IconUri = new Uri("/Assets/fb.png", UriKind.Relative);
    button.Text = "Facebook";
    button.Click += btnFB_onClick(null, null);
    button.IsEnabled = true;
    appBar.Add(button);
