        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow cw = new ChildWindow();
            cw.Width = 300;
            cw.Height = 300;
            cw.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
            cw.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
            Grid g = new Grid();
            g.Background = new SolidColorBrush(Colors.Gray);
            g.Children.Add(new TextBlock() { Text = "Child window content." });
            g.MouseLeave += ChildWindowContent_MouseLeave;
            cw.Content = g;
            cw.Show();
        }
        private void ChildWindowContent_MouseLeave(object sender, MouseEventArgs e)
        {
            ChildWindow cw = ((Grid)sender).Parent as ChildWindow;
            cw.Close();
        }
