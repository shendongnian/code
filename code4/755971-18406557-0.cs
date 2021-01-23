        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType.Equals(typeof(DateTime)))
            {
                var column = (DataGridTextColumn)e.Column;
                var dateTimeConverter = new DateTimeConverter();
                ((Binding)column.Binding).Converter = dateTimeConverter;
            }
        }
