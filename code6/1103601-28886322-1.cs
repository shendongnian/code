    // derive from base class DataTemplateSelector
    public class ArgumentTypeTemplateSelector : DataTemplateSelector
    {
        // override SelectTemplate method
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // get access to the resources you need, for example
            // by accessing the UI object where your selector is placed in
            var frameworkElement = (FrameworkElement) container;
            // return a data template depending on your custom logic,
            // you can cast "item" here to the specific type and check your conditions
            return (DataTemplate) frameworkElement.FindResource("YourDataTemplateKey");
            else
                // ...
            return base.SelectTemplate(item, container);
        }
    }
