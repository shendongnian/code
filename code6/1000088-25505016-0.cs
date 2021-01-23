    using(SPSite site = new SPSite("site url"))
    {
      using(SPWeb web = site.OpenWeb())
      {
        SPFolder folder = web.GetFolder("/Docs/folder1");
        if(folder.ItemCount > 0)
        {
          SPList list = web.Lists.TryGetList("ListName");
          SPQuery query = new SPQuery();
          query.Folder = folder;
          SPListItemCollection = list.GetItems(query);
        }
      }
    }
