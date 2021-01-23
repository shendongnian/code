    private T FindElementInVisualTree<T>(DependencyObject parentElement, int ind) where T : DependencyObject
    {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0) 
                return null;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                {
                    if (number == ind)
                    {
                        number = 0;
                        return (T)child;
                    }
                    number++;
                }
                else
                {
                    var result = FindElementInVisualTree<T>(child, ind);
                    if (result != null)
                        return result;
                }
            }
            return null;
    }
    private DataTemplate CreateDataTemplate()
    {
        string xaml =
            @"<DataTemplate
            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                <StackPanel>
                    <TextBlock Text='{Binding Title}'/>
                    ...
                    ...
                </StackPanel>
            </DataTemplate>";
        DataTemplate dt = (DataTemplate)XamlReader.Load(xaml);
        return dt;
    }
