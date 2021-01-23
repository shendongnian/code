    IEnumerable<Role> roles = model.Parse(x => new Role
                                               {
                                                   Id = (int)(RoleModel)x,
                                                   Name = ((RoleModel)x).ToString()
                                               }
                                         );
On e I do not get anything ... I was expecting to get all values of the enum. Why?
