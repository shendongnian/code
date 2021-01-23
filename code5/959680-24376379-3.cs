    public class ContentControlGenericTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate retVal = null;
            try
            {
                retVal = Core.WPF.Infrastructure.DataTemplateManager.templates[item.GetType().ToString()];
            }
            catch //empty catch to prevent design time errors..
            {
            }
            return retVal;
        }
