    var allRoles = roles.Table
        .AsEnumerable().Select(p => new FirmRole
        {
            Code = p.Field<string>("RoleName"),
            Name = p.Field<string>("RoleName")
        }).Distinct()
          .OrderBy(x => x.Item.Code.StartsWith("f")) 
          .ToList();
