    while(sqlite_datareader.Read())
    {
        System.Windows.Controls.Button starBtn = new System.Windows.Controls.Button();
        Viewbox dynamicViewbox = (Viewbox)System.Windows.Application.Current.FindResource("StarBlue");
        dynamicViewbox.StretchDirection = StretchDirection.Both;
        dynamicViewbox.Stretch = Stretch.Fill;
        Padding myPadding = new Padding();
        myPadding.All = 0;
        starBtn.Padding = new Thickness(0,0,0,0);
        starBtn.Margin = new Thickness(0,0,0,0);
        starBtn.Width = 24;
        starBtn.Height = 24;
        starBtn.Content = dynamicViewbox;
        starBtn.Style = (Style)FindResource("StarButtonStyle");
        splMain.Children.Add(starBtn);
    }
