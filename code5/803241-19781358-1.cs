     var title = type.Name;
     var path = type.FullName;//needs a bit more of processing here to make it suitable for Binding
     if(type == typeof(string))
     {
        var column = new DataGridTextColumn();
        column.Header = title;
        column.Binding = new Binding(path);
        dataGrid.Columns.Add(column);
     }
     else
     {
        //use different kind of DataGridColumn
     }
