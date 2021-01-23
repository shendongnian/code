     //member is obtained through Reflection
     var title = member.Name;
     var path = member.Name;
     //path needs a bit more of processing to make it suitable for Binding
     //e.g. make use of member.ReflectedType
     if(member.MemberType == typeof(string))
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
