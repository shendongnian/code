    StackPanel stackPanel = sender as StackPanel;
    if(stackPanel != null)
    {
            if (stackPanel.Background.Equals(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))))
            {
                stackPanel.Background = materiaColor;               
                stckTeachersGuideClosed.Visibility = Visibility.Visible;
                stckTeachersGuideOpened.Visibility = Visibility.Collapsed;
            }
            else
            {
                stackPanel.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
    }
