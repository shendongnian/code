    using (var context = new AppContext())
    {
    var userDetailsViewModels = new UserDetailsViewModel
    return View(context.GetUserDetails.Join(dataContext.SomeOtherTable,u=>u.Ut, o=>o.UserId, (u,o)=>new UserDetailsViewModel{Name = u.Name, CreatinnDate = o.CreationDate}));
    }
