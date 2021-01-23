     private void MainSurfaceListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var listBox = sender as SurfaceListBox;
                if (listBox == null) return;
                var childElement = FindChild(listBox, i => i as LoopPanelVertical);
                childElement.LineUp();
            }
    
            static T FindChild<T>(DependencyObject obj, Func<DependencyObject, T> pred) where T : class
            {
                var childrenCount = VisualTreeHelper.GetChildrenCount(obj);
                for (var i = 0; i < childrenCount; i++)
                {
                    var dependencyObject = VisualTreeHelper.GetChild(obj, i);
                    var foo = pred(dependencyObject);
                    return foo ?? FindChild(dependencyObject, pred);
                }
                return null;
            }
