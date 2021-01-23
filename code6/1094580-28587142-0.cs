    var subDepartmentList = SubDepartment.LoadList(); 
    var subdepartments = new List<ListItem>(
      from subdepartment in subDepartmentList
      where departments.Any(x => x.IsSelected && 
                            x.Value == subdepartment.DepartmentId.ToString()) 
      select new ListItem {
        Text = subdepartment.Name,
        Value = subdepartment.Id.ToString(),
        IsSelected = false
      }
    );
