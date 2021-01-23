    List<int> list = new List<int> { 1, 3 };
    List<RoleModel> parsedList = 
        list.Select(n => Enum.GetName(typeof(RoleModel), n) ?? String.Empty)
            .Where(s => !String.IsNullOrEmpty(s))
            .Select(s => (RoleModel)Enum.Parse(typeof(RoleModel), s))
            .ToList();
