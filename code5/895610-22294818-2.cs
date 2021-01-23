    var coursesList = not_subsribe
    .Select(c => new { Id = c.Cours.ID, Name = c.Cours.Name })
    .Distinct()
    .OrderBy(x => x.Name)
    .Select(x => new SelectListItem
         {
             Text = g.Key.Name,
             Value = g.Key.Id
         }); 
