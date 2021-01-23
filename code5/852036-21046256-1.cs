    private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Content.Visibility == Visibility.Collapsed)
            {
                Content.Visibility = Visibility.Visible;
            }
            else
            {
                Content.Visibility = Visibility.Collapsed;
            }
        }
