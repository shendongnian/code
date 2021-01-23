    public class DataGridDateColumn : DataGridBoundColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock textBlock = new TextBlock();
            BindingBase binding = Binding;
            if (binding != null)
            { BindingOperations.SetBinding(textBlock, TextBlock.TextProperty, Binding); }
            return textBlock;
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            DatePicker datePicker = new DatePicker();
            BindingBase binding = Binding;
            if (binding != null)
            { BindingOperations.SetBinding(datePicker, DatePicker.SelectedDateProperty, Binding); }
            return datePicker;
        }
    }
