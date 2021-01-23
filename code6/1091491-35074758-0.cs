        DeviceUtility.FindControl<ScrollViewer>(this.FlipView, typeof(ScrollViewer)).InvalidateScrollInfo();
        public static List<UIElement> GetAllChildControls(DependencyObject parent)
        {
            var controList = new List<UIElement>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var childControl = VisualTreeHelper.GetChild(parent, i);
                if (childControl is UIElement)
                {
                    controList.Add(childControl as UIElement);
                }
                controList.AddRange(GetAllChildControls(childControl));
            }
            return controList;
        }
        public static T FindControl<T>(DependencyObject parentContainer, Type controlType)
        {
            var childControls = GetAllChildControls(parentContainer);
            var control = childControls.OfType<UIElement>().Where(x => x.GetType().Equals(controlType)).Cast<T>().First();
            return control;
        }
