    public class DepthStyleSelector : StyleSelector
    {
        public Style FirstItemStyle { get; set; }
        public Style DefaultStyle { get; set; }
        public int Depth { get; set; }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (ItemsControl
                .ItemsControlFromItemContainer(container)
                .ItemContainerGenerator
                .IndexFromContainer(container) < this.Depth)
            {
                return this.FirstItemStyle;
            }
            return this.DefaultStyle;
        }
    }
