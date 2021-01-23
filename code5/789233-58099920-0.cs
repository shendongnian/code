        /// <summary>
        /// Adds or inserts a child back into its parent
        /// </summary>
        /// <param name="child"></param>
        /// <param name="index"></param>
        public static void AddToParent(this UIElement child, int? index = null)
        {
            var parent = child.GetParent(true);
            if (parent == null)
                parent = child.GetParent(false);
            if (parent == null)
                return;
            if (parent is ItemsControl itemsControl)
                if (index == null)
                    itemsControl.Items.Add(child);
                else
                    itemsControl.Items.Insert(index.Value, child);
            else if (parent is Panel panel)
                if (index == null)
                    panel.Children.Add(child);
                else
                    panel.Children.Insert(index.Value, child);
            else if (parent is Decorator decorator)
                decorator.Child = child;
            else if (parent is ContentPresenter contentPresenter)
                contentPresenter.Content = child;
            else if (parent is ContentControl contentControl)
                contentControl.Content = child;
        }
        /// <summary>
        /// Removes the child from its parent collection or its content.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool RemoveFromParent(this UIElement child, out DependencyObject parent, out int? index)
        {
            parent = child.GetParent(true);
            if (parent == null)
                parent = child.GetParent(false);
            index = null;
            if (parent == null)
                return false;
            if (parent is ItemsControl itemsControl)
            {
                if (itemsControl.Items.Contains(child))
                {
                    index = itemsControl.Items.IndexOf(child);
                    itemsControl.Items.Remove(child);
                    return true;
                }
            }
            else if (parent is Panel panel)
            {
                if (panel.Children.Contains(child))
                {
                    index = panel.Children.IndexOf(child);
                    panel.Children.Remove(child);
                    return true;
                }
            }
            else if (parent is Decorator decorator)
            {
                if (decorator.Child == child)
                {
                    decorator.Child = null;
                    return true;
                }
            }
            else if (parent is ContentPresenter contentPresenter)
            {
                if (contentPresenter.Content == child)
                {
                    contentPresenter.Content = null;
                    return true;
                }
            }
            else if (parent is ContentControl contentControl)
            {
                if (contentControl.Content == child)
                {
                    contentControl.Content = null;
                    return true;
                }
            }
            return false;
        }
        public static DependencyObject GetParent(this DependencyObject depObj, bool isVisualTree)
        {
            if (isVisualTree)
            {
                if(depObj is Visual || depObj is Visual3D)
                    return VisualTreeHelper.GetParent(depObj);
                return null;
            }
            else
                return LogicalTreeHelper.GetParent(depObj);
        }
