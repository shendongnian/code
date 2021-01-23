     //member is obtained through Reflection
     var title = member.Name;
     var path = member.Name;//note
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
