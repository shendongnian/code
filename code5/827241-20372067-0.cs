    else
        {
    model.AuthorList = _Authors.GetAuthors()
                              .Select(a => new SelectListItem { 
                                         Value = a.Id.ToString(), 
                                         Text = a.Name }
                                     ).ToList()
            return View(model);
        }
