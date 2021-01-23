        private void Child_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            int visibleChildrenCount = 0;
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (grid.Children[i].Visibility == Visibility.Visible)
                {
                    visibleChildrenCount++;
                }
            }
            //Here you can set your Rows and Columns depending on visiblechildrenCount
        }
