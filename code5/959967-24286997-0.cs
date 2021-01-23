    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
        var dataGridBoundColumn = cell.Column as DataGridBoundColumn;
        var datePicker = new DatePicker { Width = 50, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        var cellContent = cell.Content as TextBlock;
        if (dataGridBoundColumn != null)
        {
            var bindingExpression = (cell.Content as TextBlock) != null ? BindingOperations.GetBindingExpression(cellContent, TextBlock.TextProperty) : null;
            if (bindingExpression != null)
            {
                var newBindning = new Binding(bindingExpression.ParentBinding.Path.Path)
                    {
                        UpdateSourceTrigger = bindingExpression.ParentBinding.UpdateSourceTrigger, Mode = bindingExpression.ParentBinding.Mode
                    };
                datePicker.SetBinding(DatePicker.TextProperty, newBindning);
            }
        }
        return datePicker;
    }
