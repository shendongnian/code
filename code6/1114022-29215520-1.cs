    var allRoles = roles.Table
          .AsEnumerable().Select(p => new FirmRole
          {
              Code = p.Field<string>("RoleName"),
              Name = p.Field<string>("RoleName")
          }).OrderBy(x => x.Code, new CustomSortComparer()).ToList();
