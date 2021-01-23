    var model = new SearchViewModel();
            var names = dt.Columns.Select(x => new SelectListItem
            {
                Value = x.ColumnName,
                Text = x.ColumnName
            }).ToList();
     model.Names = names;
     return View(model);
