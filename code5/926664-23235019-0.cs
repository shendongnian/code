    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        if (turn == 1)
        {
            BitmapImage bmp = new BitmapImage();
            Uri u = new Uri("ms-appx:/Images/O_logo.png", UriKind.RelativeOrAbsolute);
            bmp.UriSource = u;
            // NOTE: change starts here
            Image i = new Image();
            i.Source = bmp;
            btn.Content = i;
        }
        else
        {
            BitmapImage bmp = new BitmapImage();
            Uri u = new Uri("ms-appx:/Images/X_logo.png", UriKind.RelativeOrAbsolute);
            bmp.UriSource = u;
            // NOTE: change starts here
            Image i = new Image();
            i.Source = bmp;
            btn.Content = i;
        }
        btn.IsEnabled = false;
        //win(btn.Content.ToString());
        turn += 1;
        if (turn > 2)
            turn = 1;
    }
