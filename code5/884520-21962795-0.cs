    private void b1_Clik(object sender, RoutedEventArgs e)
    {           
        if (b1.Content.ToString().Equals(ans))
        {
            b1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 255, 0));
        }
        else
        {
            b1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
        }
    }
