    vm.Role.AddRange(query.Roles.Select(r => new CreateUserViewModel.Item
                {
                    Label = r.Label,
                    RoleNumber = r.RoleNumer
                }));
