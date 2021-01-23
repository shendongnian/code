    RoleModel model = RoleModel.Admin | RoleModel.Editor;
    IEnumerable<Role> roles = model.Parse(x => new Role
                                                {
                                                   Id = Convert.ToInt32(x),
                                                   Name = Convert.ToString(x)
                                                }
                                         );
