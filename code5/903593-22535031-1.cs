    StackPanel stackPanel = sender as StackPanel;
    if(stackPanel != null)
    {
            if (stackPanel.Background.Equals(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))))
            {
                stackPanel.Background = materiaColor;
                stackPanel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                stckTeachersGuideClosed.Visibility = Visibility.Visible;
                stckTeachersGuideOpened.Visibility = Visibility.Collapsed;
            }
            else
            {
                stackPanel.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                stackPanel.Foreground = new SolidColorBrush(Color.FromArgb(255, 140, 140, 140));
            }
    }
