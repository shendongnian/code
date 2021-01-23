    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "BoxType")
        {
            var column = (DataGridBoundColumn)e.Column;
            var binding = (Binding)column.Binding;
            binding.Converter = new BoxTypeConverter();
        }
    }
