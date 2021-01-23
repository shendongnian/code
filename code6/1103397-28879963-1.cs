    var rolesToRemove = myContext.Roles.Where(r=> roleIds.Contains(r.Id)).ToArray();
    foreach(var user in myContext.Users.Where(u=> userIds.Contains(u.Id)){
       forearch(var var role in rolesToRemove) {
           user.Roles.Remove(role);
       } 
    }
    myContext.SaveChanges();
