    AddColumnsForMember(MemberInfo member, string parentPath = "")
    {
         var title = member.Name;
         var path = parentPath + (parentPath=="" ? "" : ".") + member.Name;
    
         if(member.MemberType == typeof(string))
         {
            var column = new DataGridTextColumn();
            column.Header = title;
            column.Binding = new Binding(path);
            dataGrid.Columns.Add(column);
         }
         else if(member.MemberType == typeof(bool))
         {
            //use DataGridCheckBoxColumn and so on
         }
         else
         {
              //...
         }
         
         var members = member.GetMembers();
         foreach(var m in members)
         {
              AddColumnsForMember(m, path);
         }
    }
    var memberList = selectedType.Type.GetMembers();
    foreach (var member in memberList) 
        AddColumnsForMember(MemberInfo member);
