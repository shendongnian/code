    public static class DragManager
    {
        public static void SetOffset(FrameworkElement fe, double horizontalOffset, double verticalOffset)
        {
            var trans = new TranslateTransform
            {
                X = horizontalOffset,
                Y = verticalOffset
            };
            // I don't know what may change, in terms of performance, between applying the transform or just changing the margins. I'm using the margins because the transform may be needed for some other purpose
            //fe.RenderTransform = trans;            
            fe.Margin = new Thickness(horizontalOffset, verticalOffset, 0, 0); // We just change our object's margins to reflect its new position
            // We store the current position in the objects Tag (maybe there's a better solution but I'm quite new to C#/xaml)
            fe.Tag = new Offset
            {
                VerticalValue = verticalOffset,
                HorizontalValue = horizontalOffset,
                Transform = trans
            };
        }
        public static Offset GetOffset(FrameworkElement fe)
        {
            if (fe.Tag == null) fe.Tag = new Offset();
            return (Offset)fe.Tag;
        }
        public struct Offset
        {
            public double HorizontalValue { get; set; }
            public double VerticalValue { get; set; }
            public TranslateTransform Transform { get; set; }
        }
        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null)
            {
                return null;
            }
            T foundChild = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                var childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!String.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                    // Need this in case the element we want is nested
                    // in another element of the same type
                    foundChild = FindChild<T>(child, childName);
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
    }
