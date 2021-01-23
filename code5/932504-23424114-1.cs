    var item = new PageItem()
               {
                   Id = Convert.ToInt32(rdr["Id"]),
                   ParentId = Convert.ToInt32(rdr["ParentId"]),
                   MenuText = rdr["MenuTitle"].ToString()
               });
    var parent = pageItems.Where(pi => pi.Id == item.ParentId).SingleOrDefault();
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
