    var selectedDepartmentSubDepartments = 
        from dep in departments 
        join subDep in subDepartmentList
        on dep.Value equals subDep.Id.ToString()
        where dep.IsSelected
        select new ListItem {
            Text = subDep.Name,
            Value = subDep.Id.ToString(),
            IsSelected = false
        };
    var subdepartments = new List<ListItem>(selectedDepartmentSubDepartments);
