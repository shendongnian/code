     public class PropertyTemplateSelector : DataTemplateSelector
     {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            DataTemplate template = null;
            IPropertyItem propertyItem = item as IPropertyItem;
            if (propertyItem != null)
            {
                FrameworkElement element = container as FrameworkElement;
                if (element != null)
                {
                    var value = propertyItem.Value;
                    if (value is String)
                    {
                        template = element.FindResource("dtStringValue") as DataTemplate;
                    }
                    else if (value is Int32)
                    {
                        template = element.FindResource("dtIntegerValue") as DataTemplate;
                    }
                     ....
