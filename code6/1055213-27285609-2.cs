    ParentsEditVM model = db.Parents.Find(id).Select(p => new ParentsEditVM()
    {
      ParentID = p.ParentID,
      FirstName =p.FirstName,
      LastName = p.LastName,
      Children = p.Childs.Select(c => new ChildVM()
      {
        ChildID = c.ChildID,
        Name = c.Name,
        ... etc
      });
    });
    ....
    return View(model);
