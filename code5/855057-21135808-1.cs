    public static Expression<Func<Model, ViewModel>> ToViewModel
    {
        get
        {
            return x => {
                var vm = new PositionViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
    
                vm.Employees = x.Employees.Select(p => new Employee
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Position = vm
                    }).ToList();
    
                return vm;
            }
        }
    }
    
