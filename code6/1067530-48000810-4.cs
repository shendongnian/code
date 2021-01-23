    public class DataGridProcessContainerColumn : DataGridBoundColumn
    {
        public DataTemplate ContentTemplate { get; set; }
    
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            throw new NotImplementedException();
        }
    
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var control = new ContentControl();
            control.ContentTemplate = ContentTemplate;
            BindingOperations.SetBinding(control, ContentControl.ContentProperty, Binding);
            return control;
        }
    }
