    private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Column is DataGridTemplateColumn)
        {
            BindingOperations.ClearAllBindings(e.EditingElement as ContentPresenter);
        }
    }
