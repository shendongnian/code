    var datagridTopic = new DataGrid {Width = 400, IsReadOnly = true};
    //I only need one column
    var column1 = new DataGridTextColumn()
    {
        Header = "ID",
        Width = datagridTopic.Width - 8 //after adding rows the grid gets scroll, so made column width lower
    };
    column1.Binding = new Binding("ID")
    datagridTopic.Columns.Add(column1);
    var column2 = new DataGridTextColumn()
    {
        Header = "Title",
        Width = datagridTopic.Width - 8 //after adding rows the grid gets scroll, so made column width lower
    };
    column2.Binding = new Binding("Title")
    datagridTopic.Columns.Add(column2);
    var items = xElementArray.Select(x => new { ID= x.Attribute("id").Value, Title = x.Attribute("title").Value});
    
    datagridTopic.ItemsSource = items; //set the data source for the grid to custom created items.
    StackPanelContent.Children.Add(datagridTopic);
