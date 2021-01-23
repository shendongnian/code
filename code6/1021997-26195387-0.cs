        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxQuestion.ItemsSource = new List<String> { "AAA", "BBB", "CCC" };
        }
        private void listBoxQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("You selected " + listBoxQuestion.SelectedItem.ToString());
        }
