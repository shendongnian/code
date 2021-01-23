        private void SetAlternateColor()
        {
            var blueBrush = new SolidColorBrush(Colors.Blue);
            var redBrush = new SolidColorBrush(Colors.Red);
            for (int i = 0; i < Items.Count; i++)
            {
                ListBoxItem item = TestListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                item.Background = i % 2 == 0 ? blueBrush : redBrush;
            }
        }
        private void TestGrid_Loaded(object sender, RoutedEventArgs e)
        {
            SetAlternateColor();
        }
