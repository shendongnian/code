    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Sub1Template { get; set; }
        public DataTemplate Sub2Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is sub1) { return Sub1Template; }
            if (item is sub2) { return Sub2Template; }
            return null;
        }
    }
