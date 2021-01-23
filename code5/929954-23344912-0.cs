    private void myDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var column = e.Column as DataGridBoundColumn;
        if (column != null)
        {
            var binding = column.Binding as Binding;
            if (binding != null) binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        }
    }
