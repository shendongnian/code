    private void AddColumns(string id, string name)
    {
        FrameworkElementFactory textBlock = new FrameworkElementFactory(typeof(TextBlock));
    
        textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
        textBlock.SetValue(TextBlock.TextProperty, new Binding(String.Format("[{0}]", id)));
    
        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
    
        textBox.SetValue(TextBox.PaddingProperty, new Thickness(2));
        textBox.SetValue(TextBox.TextProperty, new Binding(String.Format("[{0}]", id)));
    
        Binding textDecorationBinding = new Binding();
        textDecorationBinding.ElementName = "DataGrid";
        textDecorationBinding.Path = new PropertyPath("DataContext.TextDecoration");
    
        textBlock.SetValue(TextBlock.TextDecorationsProperty, textDecorationBinding);
    
        DataTemplate cellTemplate = new DataTemplate();
        cellTemplate.VisualTree = textBlock;
    
        DataTemplate cellEditingTemplate = new DataTemplate();
        cellEditingTemplate.VisualTree = textBox;
    
        DataGridTemplateColumn column = new DataGridTemplateColumn();
        column.Header = name;
        column.SortMemberPath = name;
        column.CellTemplate = cellTemplate;
        column.CellEditingTemplate = cellEditingTemplate;
    
        DataGrid.Columns.Add(column);
    }
