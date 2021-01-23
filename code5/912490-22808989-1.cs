    public class MyItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OneTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            bool myItem = (bool)item;
            if (myItem == true)
            {
                return OneTemplate;
            }
            return SecondTemplate;
        }
    }
