     var ddlList = cList.OfType<DropDownList>();
     
     ListItemCollection itemCollection = new ListItemCollection();
     // option 1
     var temp = ddlList.Select(ddl => ddl.Items.Cast<ListItem>()).SelectMany(li => li).ToArray();
     itemCollection.AddRange(temp);
     // or option 2
     var temp = ddlList.Select(ddl => ddl.Items.Cast<ListItem>()).SelectMany(li => li);
     foreach (var listItem in temp)
     {
         itemCollection.Add(listItem);
     }
