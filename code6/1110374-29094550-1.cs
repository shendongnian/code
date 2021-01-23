    [HttpPost]
    public ActionResult Save(PeopleListViewModel viewModel)
    {
        List<People> selected = viewModel.People
            .Where(p => p.IsSelected)
            .ToList();
        if (selected.Any())
        { 
           //it's valid
          List<int> selectedIds = selected
              .Select(s => s.PersonID)
              .ToList();
        }
        return View("Index", viewModel);
    }
