    public class MenuNameDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var menuItem = item as MenuItem;
            var element = container as FrameworkElement;
            if (menuItem != null || element != null)
            {
                while (element != null)
                {
                    while (element != null)
                    {
                        if (element.Resources.ContainsKey(menuItem.Name))
                        {
                            var template = element.Resources[menuItem.Name] as DataTemplate;
                            if (template != null)
                                return template;
                        }
                        else
                        {
                            element = VisualTreeHelper.GetParent(element) as FrameworkElement;
                            if (element == null)
                                element = element.Parent as FrameworkElement;
                        }
                    }
                }
            }
            return base.SelectTemplateCore(item, container);
        }
    }
