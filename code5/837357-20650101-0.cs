    ICollection<UserInApplication> userInAppRole=new Collection<UserInApplication>(); //Initialize this
    IEnumerable<UserInApplication> result=null;
    result = _userService.UserInApplicationRoles(iAppRoleId,collection["displayName"])
                         .AsEnumerable();
     userInAppRole = result.AddTo(userInAppRole); 
