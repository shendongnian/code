    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataTemplate template = null;
        
        // Four lines below replace the DataTemplateSelector
        if (e.PropertyType.IsAssignableFrom(typeof(IEnumerable<MyClass2>)))
            template = (DataTemplate)Resources["MyClass2CollectionTemplate"];
        else if (e.PropertyType.IsAssignableFrom(typeof(MyClass2)))
            template = (DataTemplate)Resources["MyClass2Template"];
    
        if (template != null)
        {
            var col = new DataGridProcessContainerColumn();
            col.Binding = (e.Column as DataGridBoundColumn).Binding;
            col.ContentTemplate = template;
            col.Header = e.Column.Header;
            e.Column = col;
        }
    }
