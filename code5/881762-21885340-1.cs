    var users = _myContext.Users
               .ToList()
               .Select(x => new UserDetail(x) {
                         IsOnline = _myUserService.IsOnline(x.Id)
                     });
    return View["MyView", users];
