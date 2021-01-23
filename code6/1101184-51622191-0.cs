    if (e.PropertyType == typeof(int))
    {
        DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
        if (dataGridTextColumn != null)
        {
            dataGridTextColumn.Binding.StringFormat = "{0:p}";
        }
     }
