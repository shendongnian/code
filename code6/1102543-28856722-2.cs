    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        Binding binding;
        DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
        if(dataGridTextColumn != null)
        {
            binding = new Binding(String.Concat("[", dataGridTextColumn.Header, "]"));
            binding.Mode = BindingMode.TwoWay;
            binding.ValidationRules.Add(new MyValidationRule());
    
            dataGridTextColumn.Binding = binding;
        }
    }
