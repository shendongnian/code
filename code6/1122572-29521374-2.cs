    while(sqlite_datareader.Read())
    {
        System.Windows.Controls.Button starBtn = new System.Windows.Controls.Button();
        Viewbox dynamicViewbox = (Viewbox)System.Windows.Application.Current.FindResource("StarBlue");
        dynamicViewbox.StretchDirection = StretchDirection.Both;
        dynamicViewbox.Stretch = Stretch.Fill;
        starBtn.Style = (Style)FindResource("StarButtonStyle");
        starBtn.Padding = new Thickness(0,0,0,0);
        starBtn.Margin = new Thickness(0,0,0,0);
        starBtn.Width = 24;
        starBtn.Height = 24;
        starBtn.Content = dynamicViewbox;
        splMain.Children.Add(starBtn);
    }
