    public class GroupedComboBox : ComboBox
    {
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }
        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(GroupedComboBox), new PropertyMetadata(null));
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var container = element as ComboBoxItem;
            if (container != null && item is ComboBoxGroupHeader)
            {
                // prevent selection
                container.IsHitTestVisible = false;
                // adjust the container to display the header content
                container.ContentTemplate = HeaderTemplate
                container.Content = ((ComboBoxGroupHeader)item).Header;
            }
        }
    }
