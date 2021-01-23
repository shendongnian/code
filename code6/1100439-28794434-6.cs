    private void OnDataGridAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        PropertyInfo propertyInfo;
        PropertyDescriptor propertyDescriptor;
        IEnumerable attributes;
    
        if ((propertyInfo = e.PropertyDescriptor as PropertyInfo) != null)
        { attributes = propertyInfo.GetCustomAttributes(); }
        else if ((propertyDescriptor = e.PropertyDescriptor as PropertyDescriptor) != null)
        { attributes = propertyDescriptor.Attributes; }
        else
        { return; }
    
        ColumnAttribute attribute = attributes
            .OfType<ColumnAttribute>()
            .FirstOrDefault();
    
        if (attribute != null)
        { e.Column = attribute.CreateColumn(myDataGrid, e.PropertyDescriptor); }
    }
