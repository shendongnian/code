    foreach (var dataRow in userDetails.AsEnumerable())
    {
                    TUser user = (TUser)Activator.CreateInstance(typeof(TUser));
                    user.Id = dataRow.Field<Guid>("Id");
                    user.UserName = dataRow.Field<string>("Username");
                    user.Password = dataRow.Field<string>("Password");
                    
                    users.Roles = roles.Where(r=>r.UserId = user.Id)
                                 .Select(r=>new Roles(ID=r.RoleId,Name=r.RoleName).ToList()
                    users.Add(user); // Users is list
     }
