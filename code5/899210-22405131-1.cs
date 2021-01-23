    using (var context = new ClientContext(webUrl))
    {
          var list = context.Web.Lists.GetByTitle(listTitle);
          var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
          context.Load(items);
          context.ExecuteQuery();
    
    
          foreach (var item in items)
          {
             var folder = GetListItemFolder(item); //get Folder
             Console.WriteLine(folder.Name);
          }
    }
