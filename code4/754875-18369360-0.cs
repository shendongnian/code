    List<Department> clones = new List<Department>(selected_departments.Count);                   
    for (int i = 0; i < selected_departments.Count; i++)
    {
        clones.Add(new Department(selected_departments[i].Lft, selected_departments[i].Rgt));
    }
