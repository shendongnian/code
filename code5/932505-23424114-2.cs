    var allItems = new List<PageItem>();
    while (rdr.Read())
    {
       var item = new PageItem()
                  {
                      Id = Convert.ToInt32(rdr["Id"]),
                      ParentId = Convert.ToInt32(rdr["ParentId"]),
                      MenuText = rdr["MenuTitle"].ToString()
                  });
       allItems.Add(item);
       var parent = allItems.Where(pi => pi.Id == item.ParentId).SingleOrDefault();
       if (parent == null)
       {
          pageItems.Add(item);
       }
       else
       {
          if (parent.Childs == null)
             parent.Childs = new List<PageItem>();
          parent.Childs.Add(item);
       }
    }
