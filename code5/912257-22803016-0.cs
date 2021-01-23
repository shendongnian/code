       Please try this code
  
        if (searchBy == "Gender")
        {
            employee = employee.Where(x => x.Gender == search || search == null).ToPagedList(Page ?? 1,3);
        }
        else
        {
            employee = employee.Where(x => x.FUllName .StartsWith(search ) || search == null).ToPagedList(Page ?? 1,3);
        }
         switch (sortBy)
        {
            case "Name desc":
                employee = employee.OrderByDescending(x => x.FUllName);
                break;
            case "Default":
                employee = employee.OrderBy(x => x.FUllName);
                break;
        }
          return View( employee);
