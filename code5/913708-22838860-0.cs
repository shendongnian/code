    private void sh_Click_1(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                TextBox texbox = new TextBox();
                texbox.Width = button.ActualWidth;
                texbox.Height = button.ActualHeight;
                texbox.Text = button.Content.ToString();
                button.Visibility = Visibility.Collapsed;
                ((Grid)button.Parent).Children.Add(texbox);
                Grid.SetRow(texbox, Grid.GetRow(button));
                Grid.SetColumn(texbox, Grid.GetColumn(button));
            }
        } 
