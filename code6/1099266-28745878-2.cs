    List<User> userEntity = users.Where(s => s.Id == Id).ToList();
    
    var GetUserNames = userEntity.SelectMany(s => s.Names.Select(u =>
        new
        {
            Name = u.Name,
            Id = u.Id
        })).ToList();
    
    var GetProfile = userEntity.SelectMany(s => s.Profile.Select(u =>
      new
      {
          Name = u.Name,
          Id = u.Id
      })).ToList();
    
    return Json(GetUserNames.Concat(GetProfile) , JsonRequestBehavior.AllowGet);
