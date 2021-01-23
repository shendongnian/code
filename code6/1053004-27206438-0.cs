    List<UserList> tables = dtTemplates.AsEnumerable()
        .Select(t => new UserList
        {
            Name = t["Name"],
            Record = t["Record"]
        }).ToList();
