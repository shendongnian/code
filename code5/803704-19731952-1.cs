    XElement depName = company.Descendants("departmentname")
                              .Where(x => x.Value == "Dep 1")
                              .FirstOrDefault();
    
    XElement[] men = depName.Parent.Descendants("gender")
                            .Where(x => x.Value == "male")
                            .ToArray();
    
    int count = men.Length;
