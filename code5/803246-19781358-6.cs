    AddColumnsForMember(PropertyInfo property, string parentPath = "")
    {
         var title = property.Name;
         var path = parentPath + (parentPath=="" ? "" : ".") + property.Name;
    
         if(property.PropertyType == typeof(string))
         {
            var column = new DataGridTextColumn();
            column.Header = title;
            column.Binding = new Binding(path);
            dataGrid.Columns.Add(column);
         }
         else if(property.PropertyType == typeof(bool))
         {
            //use DataGridCheckBoxColumn and so on
         }
         else
         {
              //...
         }
         
         var properties = member.GetProperties();
         foreach(var item in properties)
         {
              AddColumnsForMember(item, path);
         }
    }
