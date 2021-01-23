    int y = 0;
    
            private void btnAddTitle_Click(object sender, RoutedEventArgs e)
            {
                TextBox x = new TextBox();
                x.Name = "new_textbox" + y;
                x.TextWrapping = TextWrapping.Wrap;
                x.Height = 25;
                x.Width = 200;
                x.AcceptsReturn = true;
                x.Margin = new Thickness(10, 15, 950, 0);
                spStandard.Children.Add(x);
                y++;
            }
