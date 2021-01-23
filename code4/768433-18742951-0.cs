            DependencyObject prop = sender as DependencyObject;
            while (prop != null && !(prop is ComboBox))
            {
                prop = LogicalTreeHelper.GetParent(prop);
            }
            if (prop != null)
            {
                ((ComboBox) prop).IsDropDownOpen = false;
            }
