    public class DepthTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InDepthTemplate { get; set; }
        public Type Type { get; set; }
        public int Depth { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var next = container;
            int itemsControlCount = 0;
            while (VisualTreeHelper.GetParent(next) != null)
            {
                var current = VisualTreeHelper.GetParent(next);
                if (current.GetType() == this.Type)
                {
                    itemsControlCount++;
                }
                next = current;
            }
            if (itemsControlCount <= this.Depth)
            {
                return this.InDepthTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
