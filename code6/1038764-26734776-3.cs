    namespace TextBindingFormatting
    {
        public class MyTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var element = container as FrameworkElement;
                if (element == null || item == null)
                    return base.SelectTemplate(item, container);
            if (item.ToString() == "1")
                return element.FindResource("Template1") as DataTemplate;
            
            if (item.ToString() == "2")
                return element.FindResource("Template2") as DataTemplate;
            return base.SelectTemplate(item, container);
        }
        }
    }
