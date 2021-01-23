    try
    {  
      ClientContext _context = new ClientContext(_url);
      var list = _context.Web.Lists.GetByTitle(ListName);
      ListItem item = list.GetItemById(id);
      _context.Load(item, i => i[Description], i => i[Picture], i => i[Title], i => i.Id);
      _context.ExecuteQuery();
    }
    finally
    {  
      _context.Dispose();
    }
