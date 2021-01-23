    var datagridTopic = new DataGrid {Width = 400, IsReadOnly = true};
    //I only need one column
    var column = new DataGridTextColumn()
    {
        Header = "Topic",
        Width = datagridTopic.Width - 8 //after adding rows the grid gets scroll, so made column width lower
    };
    column.Binding = new Binding("text")
    datagridTopic.Columns.Add(column);
    
    datagridTopic.ItemsSource = xElementArray; //set the data source for the grid to your XElement array.    
    StackPanelContent.Children.Add(datagridTopic);
