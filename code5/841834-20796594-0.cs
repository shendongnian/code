     private void stackPanel1_Click(object sender, RoutedEventArgs e)
        {
            if (((UserControl1)e.Source).Tag.ToString() == "1")
            {
                stackPanel1.Children.Remove(((UserControl1)e.Source));
            }
            else
            {
                MessageBox.Show("Another button was clicked");
            }
            
        }
