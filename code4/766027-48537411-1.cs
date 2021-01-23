    private void Grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(DateTime))
        {
            e.Column = new DataGridDateTimeColumn((DataGridBoundColumn)e.Column);
        }
    }
    internal class DataGridDateTimeColumn : DataGridBoundColumn
    {
        public DataGridDateTimeColumn(DataGridBoundColumn column)
        {
            Header = column.Header;
            Binding = (Binding)column.Binding;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var control = new TextBlock();
            BindingOperations.SetBinding(control, TextBlock.TextProperty, Binding);
            return control;
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var control = new DatePicker();
            control.PreviewKeyDown += Control_PreviewKeyDown;
            BindingOperations.SetBinding(control, DatePicker.SelectedDateProperty, Binding);
            BindingOperations.SetBinding(control, DatePicker.DisplayDateProperty, Binding);
            return control;
        }
        private void Control_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                DataGridOwner.CommitEdit();
            }
        }
    }
