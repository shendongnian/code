        void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grid g = null;
            ListBox lb = sender as ListBox;
            if (lb != null && lb.SelectedIndex >= 0)
            {
                // Find the top-level grid
                var parent = VisualTreeHelper.GetParent(lb);
                while (parent != null)
                {
                    if (parent.GetType() == typeof(Grid))
                    {
                        if ((parent as Grid).Name.Equals("LayoutRoot"))
                        {
                            g = (Grid)parent;
                            break;
                        }
                    }
                    parent = VisualTreeHelper.GetParent(parent);
                }
                // Found the LayoutRoot, find the textblock
                if (g != null)
                {
                    for (int i = 0; i < g.Children.Count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(g, i);
                        if (child is TextBlock)
                        {
                            (child as TextBlock).Text = (string)lb.SelectedItem;
                            break;
                        }
                    }
                }
            }
        }
