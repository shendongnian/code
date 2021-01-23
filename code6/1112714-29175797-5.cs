    public class ItemTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            PropertyWrapper propertyWrapper = (PropertyWrapper)item;
            FrameworkElement frameworkElement = (FrameworkElement)container;
            DataTemplate dataTemplate = (DataTemplate)frameworkElement.TryFindResource(propertyWrapper.PropertyType);
    
            return dataTemplate;
        }
    }
