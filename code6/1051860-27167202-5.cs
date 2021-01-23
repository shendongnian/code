    var viewModel = new AssignRolesModel
                   {
                       User = user,
                       Roles = db.Roles
                                 .Select(x => 
                                    new SelectListItem()
                                    {
                                        Text = x.RoleName,
                                        Value = SqlFunctions.StringConvert((double) x.ID)
                                    })
                                 .ToList()
                   };
    return View(viewModel);
