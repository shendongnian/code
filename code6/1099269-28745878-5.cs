    List<User> userEntity = users.Where(s => s.Id == Id).ToList();
    
    var GetUserNames = userEntity.SelectMany(s => s.Names.Select(u =>
        new NameId
        {
            Name = u.Name,
            Id = u.Id,
            Type = ThisType.username
        })).ToList();
    
    var GetProfile = userEntity.SelectMany(s => s.Profile.Select(u =>
      new NameId
      {
          Name = u.Name,
          Id = u.Id,
          Type = ThisType.profile
      })).ToList();
    
    return Json(GetUserNames.Concat(GetProfile) , JsonRequestBehavior.AllowGet);
