    public class Selector : DataTemplateSelector
    {
        //Template for RowType==Bool
        public DataTemplate Template1 { get; set; }
        //Template for RowType==Int32
        public DataTemplate Template2 { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var row = item as Row;
            if (row == null) return null;
            switch (row.RowType)
            {
                case RowType.Bool:
                    return Template1;
                case RowType.Int32:
                    return Template2;
                default:
                    return null;
            }
        }
    }
