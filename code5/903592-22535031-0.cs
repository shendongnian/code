    Button btn = sender as Button;
    if(btn != null)
    {
            if (btn.Background.Equals(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))))
            {
                btn.Background = materiaColor;
                btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                stckTeachersGuideClosed.Visibility = Visibility.Visible;
                stckTeachersGuideOpened.Visibility = Visibility.Collapsed;
            }
            else
            {
                btn.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 140, 140, 140));
            }
    }
