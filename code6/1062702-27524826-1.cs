      private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e)
            {
                 NameScope.SetNameScope(grid, new NameScope());
                 Label timeLabel = new Label();
                 timeLabel.Name = "label1";
                 grid.RegisterName("label1", timeLabel);
                timeLabel.Content = "06:00";                
            }
            void ClickEvent(object sender, RoutedEventArgs e)
            {
                Grid test = (Grid)sender;
                if (test != null)
                {
                    Label label = (Label)test.FindName("label1");
                    MessageBox.Show(label.Content.ToString());
                }
        }
