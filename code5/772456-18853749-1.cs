    private Organisation SortedOrganisation(Organisation x) {
        return new Organisation {
            x.Code
        ,   x.Type
        ,   x.Name
        ,   Departments = x.Departmentsd.OrderBy(d => d.Code).ThenBy(d => d.Name)
            .Select(d => new Department {
                d.Code
            ,   d.Name
            ,   Employees = d.Employees.OrderBy(e => e.Code).ThenBy(e => e.Name).ToList()
            })
        };
    }
    ...
    var legalEntitiesCollectionByType = new Dictionary<string, ICollection<Organisation>>
            {
                {
                    "Institutional", organisations
                        .Where(x => x.Type == "Institutional")
                        .OrderBy(x => x.Code).ThenBy(x => x.Name)
                        .Select(SortedOrganisation)
                        .ToList()
                },
                {
                    "Retail", organisations
                        .Where(x => x.Type == "Retail")
                        .OrderBy(x => x.Code).ThenBy(x => x.Name)
                        .Select(SortedOrganisation)
                        .ToList()
                }
            };
