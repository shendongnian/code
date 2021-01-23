      private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Grid grid = new Grid();
    
                Label timeLabel = new Label();
                timeLabel.RegisterName("label1", timeLabel);
                timeLabel.Content = "06:00"; //this could be anything
              
    
               
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
