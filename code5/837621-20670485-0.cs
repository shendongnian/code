    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string colName = e.PropertyName;
        if (someCondition)
        {
            string xaml = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""><ContentControl Content=""{0}"" ContentTemplate=""{1}"" /></DataTemplate>";
            var tmpl = (DataTemplate)XamlReader.Load(string.Format(xaml, "{Binding " + colName + "}", "{StaticResource customCellTemplate}"));
            var templateColumn = new DataGridTemplateColumn();
            templateColumn.CellTemplate = tmpl;
            templateColumn.Header = colName;
            templateColumn.SortMemberPath = colName;
            e.Column = templateColumn;
         }
    }
