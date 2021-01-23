    IEnumerable<SelectListItem> items = db.TodoMemberships.Select(c => new SelectListItem
                   {
                     Value =SqlFunctions.StringConvert((double)c.Id),
                     Text = c.Category
                   });
