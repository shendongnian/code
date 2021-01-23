     if(type == typeof(string))
     {
        var column = new DataGridTextColumn();
        column.Header = type.Name;
        column.Binding = new Binding(type.Name);
        dataGrid.Columns.Add(column);
     }
     else if(type == typeof(something else))
     {
        //use different kind of DataGridColumn
     }
