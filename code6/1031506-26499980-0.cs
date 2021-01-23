    IEnumerable<SelectListItem> items = db.TodoMemberships.Select(c => new SelectListItem
                   {
                     Value =SqlFunctions.StringConvert(c.Id),
                     Text = c.Category
                   });
