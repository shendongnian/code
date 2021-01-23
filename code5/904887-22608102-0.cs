        // Turn the background red when the tab width changes
        public void MeasureFirstTab()
        {
            // Remember the previous selected item
            object selectedItem = TestTabControl.SelectedItem;
            Grid measureBox = new Grid();
            UIElement content;
            // Iterate through all items
            foreach (TabItem obj in TestTabControl.Items)
            {
                // Get the tab content into the grid
                TestTabControl.SelectedItem = obj;
                content = (UIElement)obj.Content;
                obj.Content = null;
                measureBox.Children.Add(content);
                // Measure the content
                content.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                if (content.DesiredSize.Width > 500)
                {
                    this.Background = Brushes.Red;
                }
                // Return the content to its rightful owner
                measureBox.Children.Clear();
                obj.Content = content;
            }
            // Reset the tab control
            TestTabControl.SelectedItem = selectedItem;
        }
